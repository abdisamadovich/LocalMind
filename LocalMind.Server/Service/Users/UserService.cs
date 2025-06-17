using LocalMind.Server.Models.Users;
using LocalMind.Server.Repository.Users;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMind.Server.Service.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async ValueTask<User> AddUserAsync(User user)
        {
            DateTimeOffset now = DateTimeOffset.UtcNow;
            user.CreatedAt = now;
            user.UpdatedAt = now;
            return await this._userRepository.InsertUserAsync(user);
        }

        public IQueryable<User> RetriewAllUsers()
        {
            return this._userRepository.SelectAllUsers();
        }
    }
}