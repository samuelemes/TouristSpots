using Microsoft.AspNetCore.Identity;

namespace TouristSpotsDomain.Entities.Security
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
