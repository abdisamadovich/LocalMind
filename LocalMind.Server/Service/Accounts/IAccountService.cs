using LocalMind.Server.Models.UserCredentials;
using LocalMind.Server.Models.UserTokens;
using System.Threading.Tasks;

namespace LocalMind.Server.Service.Accounts
{
    public interface IAccountService
    {
        ValueTask<UserToken> LoginAsync(UserCredential userCredential);
    }
}