using Microsoft.AspNetCore.Identity;
using TouristSpotsDomain.Interface.Repositories;

namespace TouristSpotsData.Repositories
{
    public class UserRepository : RepositoryBase<IdentityUser<int>>, IUserRepository
    {
    }
}
