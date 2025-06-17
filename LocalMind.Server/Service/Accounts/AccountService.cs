using LocalMind.Server.CustomExceptions;
using LocalMind.Server.Models.UserCredentials;
using LocalMind.Server.Models.Users;
using LocalMind.Server.Models.UserTokens;
using LocalMind.Server.Repository.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LocalMind.Server.Service.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AccountService(IUserRepository userRepository, IConfiguration configuration)
        {
            this._userRepository = userRepository;
            this._configuration = configuration;
        }

        public async ValueTask<UserToken> LoginAsync(UserCredential userCredential)
        {
            User maybeUser =
                await this._userRepository.SelectAllUsers()
                    .FirstOrDefaultAsync(u => u.UserName == userCredential.UserName &&
                        u.Password == userCredential.Password);
            if (maybeUser == null)
            {
                throw new NotFoundException("User is not found with given username or password!");
            }

            return GenerateUserToken(maybeUser);
        }

        private UserToken GenerateUserToken(User user)
        {
            string secretKey = this._configuration["AuthConfiguration:Key"];
            string issuer = this._configuration["AuthConfiguration:Issuer"];
            string audience = this._configuration["AuthConfiguration:Audience"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim("FullName", $"{user.FirstName} {user.LastName}")
            };

            DateTime expirationDate = DateTime.Now.AddMinutes(30);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expirationDate,
                signingCredentials: credentials
            );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserToken
            {
                Token = tokenString,
                ExpirationDate = expirationDate
            };
        }
    }
}