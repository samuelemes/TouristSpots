using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TouristSpotsDomain.Entities.Security;
using TouristSpotsService.Interfaces;
using TouristSpotWebApi.Controllers;

namespace TouristSpotsApi.Controllers
{
    [Authorize]
    public class LoginController : ApiControllerBase<AppUser>
    {
        public static IWebHostEnvironment _environment;
        private readonly IUserService _service;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(
            UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager, 
            IUserService service) 
            : base(userManager, signInManager, service)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _service = service;
        }

        [Authorize]
        public override IActionResult Create([FromHeader] AppUser user, [FromBody] AppUser model)
        {

            return base.Create(user, model);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account", new { returnUrl = returnUrl });

            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        private async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            AppUserLogin login = new AppUserLogin
            {

            };
            return null;
        }
    }
}
