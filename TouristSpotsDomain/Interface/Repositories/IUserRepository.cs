using Microsoft.AspNetCore.Identity;

namespace TouristSpotsDomain.Interface.Repositories
{
    public interface IUserRepository : IRepositoryBase<IdentityUser<int>>
    {
    }
}
