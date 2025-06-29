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
            _userRepository = userRepository;
            _userAdditionalDetailRepository = userAdditionalDetailRepository;
        }

        public async ValueTask<User> AddUserAsync(User user)
        {
            DateTimeOffset now = DateTimeOffset.UtcNow;
            user.CreatedAt = now;
            user.UpdatedAt = now;
            await this._userRepository.InsertUserAsync(user);

            if(user.UserAdditionalDetail != null)
            {
                await this._userAdditionalDetailRepository
                    .InsertUserAdditionalDetailAsync(user.UserAdditionalDetail);
            }

            return user;
        }

        public IQueryable<User> RetriewAllUsers()
        {
            return this._userRepository.SelectAllUsers();
        }
    }
}