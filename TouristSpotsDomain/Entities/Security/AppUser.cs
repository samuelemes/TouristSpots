using TouristSpotsDomain.Base;

namespace TouristSpotsDomain.Entities.Security
{
    public class AppUser : BaseEntity//, IdentityUser<int>, IUser<int>
    {
        //public int Id { get; set; }
        //public string UserName { get; set; }
        //public string Email { get; set; }
        ////public string NormalizeUserName { get; set; }
        //public string PasswordHash { get; set; }
        public bool IsAdmin { get; internal set; }
    }
}
