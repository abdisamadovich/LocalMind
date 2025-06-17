using LocalMind.Server.Models.Users;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMind.Server.Repository.Users
{
    public interface IUserRepository
    {
        ValueTask<User> InsertUserAsync(User user);

        IQueryable<User> SelectAllUsers();
    }
}