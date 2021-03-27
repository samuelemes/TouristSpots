using TouristSpotsDomain.Entities.Security;
using TouristSpotsDomain.Interface.Repositories;

namespace TouristSpotsData.Repositories
{
    public class UserRepository : RepositoryBase<AppUser>, IUserRepository
    {
    }
}
