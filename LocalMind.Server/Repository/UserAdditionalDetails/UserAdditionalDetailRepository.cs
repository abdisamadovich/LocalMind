using LocalMind.Server.DataContext;
using LocalMind.Server.Models.UserAdditionalDetails;
using System.Threading.Tasks;

namespace LocalMind.Server.Repository.UserAdditionalDetails;

public class UserAdditionalDetailRepository : IUserAdditionalDetailRepository
{
    private readonly ApplicationDbContext applicationDbContext;

    public UserAdditionalDetailRepository(ApplicationDbContext applicationDbContext)
    {
        this.applicationDbContext = applicationDbContext;
    }

    public async ValueTask<UserAdditionalDetail> InsertUserAdditionalDetailAsync(UserAdditionalDetail userAdditionalDetail)
    {
        await this.applicationDbContext.userAdditionalDetails.AddAsync(userAdditionalDetail);

        return userAdditionalDetail;
    }
}
