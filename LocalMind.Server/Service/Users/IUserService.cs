using LocalMind.Server.DTOs;
using LocalMind.Server.Models.Users;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMind.Server.Service.Users
{
    public interface IUserService
    {
        ValueTask<UserDto> AddUserAsync(UserDto userDto);
        IQueryable<UserDto> RetriewAllUsers();
    }
}