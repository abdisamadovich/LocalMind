using LocalMind.Server.Models.Users;
using LocalMind.Server.Service.Users;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMind.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async ValueTask<IActionResult> PostUserAsync([FromBody] User user)
        {
            User newUser = await this._userService.AddUserAsync(user);
            return StatusCode(201, newUser);
        }

        [HttpGet]
        public ActionResult<IQueryable<User>> GetAllUsers()
        {
            IQueryable<User> users = this._userService.RetriewAllUsers();
            return Ok(users);
        }
    }
}