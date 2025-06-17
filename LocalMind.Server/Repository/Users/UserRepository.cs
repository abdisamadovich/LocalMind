using LocalMind.Server.DataContext;
using LocalMind.Server.Models.Users;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMind.Server.Repository.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async ValueTask<User> InsertUserAsync(User user)
        {
            await this.context.Users.AddAsync(user);
            return user;
        }

        public IQueryable<User> SelectAllUsers() => this.context.Users;
    }
}