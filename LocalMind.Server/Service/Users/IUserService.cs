using LocalMind.Server.Models.Users;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMind.Server.Service.Users
{
    public interface IUserService
    {
        ValueTask<User> AddUserAsync(User user);

        IQueryable<User> RetriewAllUsers();
    }
}