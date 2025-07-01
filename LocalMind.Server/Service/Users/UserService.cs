using LocalMind.Server.DTOs;
using LocalMind.Server.Helpers;
using LocalMind.Server.Models.Users;
using LocalMind.Server.Repository.UserAdditionalDetails;
using LocalMind.Server.Repository.Users;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMind.Server.Service.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserAdditionalDetailRepository _userAdditionalDetailRepository;

        public UserService(IUserRepository userRepository, 
            IUserAdditionalDetailRepository userAdditionalDetailRepository)
        {
            this._userRepository = userRepository;
            this._userAdditionalDetailRepository = userAdditionalDetailRepository;
        }

        public async ValueTask<UserDto> AddUserAsync(UserDto userDto)
        {
            User user = MapToUser(userDto);
            user.HashedPassword = HashingHelper.GetHash(userDto.Password);

            await this._userRepository.InsertUserAsync(user);

            if (user.UserAdditionalDetail != null)
            {
                await this._userAdditionalDetailRepository
                    .InsertUserAdditionalDetailAsync(user.UserAdditionalDetail);
            }

            return userDto;
        }

        public IQueryable<UserDto> RetriewAllUsers()
        {
            return this._userRepository.SelectAllUsers()
                .Select(MapToUserDto).AsQueryable();
        }

        private static User MapToUser(UserDto userDto)
        {
            DateTimeOffset now = DateTimeOffset.UtcNow;
            Guid newId = Guid.NewGuid();

            return new User
            {
                Id = newId,
                UserName = userDto.UserName,
                HashedPassword = userDto.Password,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                PhoneNumber = userDto.PhoneNumber,
                Role = userDto.Role,
                CreatedAt = now,
                UpdatedAt = now,
                UserAdditionalDetail = userDto.UserAdditionalDetail
            };
        }

        private static UserDto MapToUserDto(User user)
        {
            return new UserDto
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
                UserAdditionalDetail = user.UserAdditionalDetail
            };
        }
    }
}