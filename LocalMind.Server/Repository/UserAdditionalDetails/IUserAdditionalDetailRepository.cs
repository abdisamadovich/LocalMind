using LocalMind.Server.Models.UserAdditionalDetails;
using System.Threading.Tasks;

namespace LocalMind.Server.Repository.UserAdditionalDetails;

public interface IUserAdditionalDetailRepository
{
    ValueTask<UserAdditionalDetail> InsertUserAdditionalDetailAsync (UserAdditionalDetail userAdditionalDetail); 
}
