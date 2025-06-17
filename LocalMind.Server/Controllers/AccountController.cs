using LocalMind.Server.Models.UserCredentials;
using LocalMind.Server.Models.UserTokens;
using LocalMind.Server.Service.Accounts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LocalMind.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            this._accountService = accountService;
        }

        [HttpPost]
        public async ValueTask<ActionResult> LoginAsync([FromBody] UserCredential userCredential)
        {
            UserToken userToken = await this._accountService.LoginAsync(userCredential);

            return Ok(userToken);
        }
    }
}