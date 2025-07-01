using LocalMind.Server.DTOs;
using LocalMind.Server.Models.Users;
using LocalMind.Server.Service.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMind.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<User>> PostUserAsync([FromBody] UserDto userDto)
        {
            UserDto newUser = await this._userService.AddUserAsync(userDto);
            return StatusCode(201, newUser);
        }

        [HttpGet]
        public ActionResult<IQueryable<UserDto>> GetAllUsers()
        {
            IQueryable<UserDto> users = this._userService.RetriewAllUsers();

            return Ok(users);
        }
    }
}