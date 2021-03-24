using Microsoft.AspNetCore.Identity;
using TouristSpotsDomain.Entities.Security;

namespace TouristSpotsApi.Framework
{
    public sealed class AppUserManager : UserManager<AppUser>
    {
        #region Constructors and Destructors


        public AppUserManager(AppUserStore store)
            : base(store)
        {
        }

        #endregion

        #region Public Methods and Operators

        //public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        //{
        //    var manager = new AppUserManager(new AppUserStore(context.Get<AppDbContext>()));
        //    // Configurar a lógica de validação para nomes de usuário
        //    manager.UserValidator = new UserValidator<AppUser, int>(manager)
        //                            {
        //                                AllowOnlyAlphanumericUserNames = false,
        //                                RequireUniqueEmail = true
        //                            };
        //    // Configurar a lógica de validação para senhas
        //    manager.PasswordValidator = new PasswordValidator
        //                                {
        //                                    RequiredLength = 6,
        //                                    RequireNonLetterOrDigit = true,
        //                                    RequireDigit = true,
        //                                    RequireLowercase = true,
        //                                    RequireUppercase = true
        //                                };
        //    var dataProtectionProvider = options.DataProtectionProvider;
        //    if (dataProtectionProvider != null)
        //        manager.UserTokenProvider =
        //            new DataProtectorTokenProvider<AppUser, int>(dataProtectionProvider.Create("ASP.NET Identity"));
        //    return manager;
        //}

        #endregion
    }
}