using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TouristSpotsData;
using TouristSpotsDomain.Entities.Security;

namespace TouristSpotsApi.Framework
{
    public class AppUserStore : UserStore<AppUser, AppRole, AppDbContext, int, AppUserClaim, AppUserRole, AppUserLogin, AppUserToken, AppRoleClaim>
    {
        #region Constructors and Destructors

        public AppUserStore()
            : base(AppDbContext.Create())
        {
        }

        public AppUserStore(AppDbContext context) : base(context)
        {
        }

        #endregion

        //public override Task<USUARIO> FindByNameAsync(string userName)
        //{
        //    var user = ((AtegDbContext)Context).Users.FirstOrDefault(w => w.UserName.Equals(userName));
        //    var usernames = ((AtegDbContext)Context).Users.Select(s => s.UserName);

        //    return Task.FromResult(user) ?? base.FindByNameAsync(userName);
        //}
    }
}