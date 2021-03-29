using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TouristSpotsDomain.Entities;
using TouristSpotsDomain.Entities.Security;
using TouristSpotsService.Interfaces;

namespace TouristSpotWebApi.Controllers
{
    [Produces("application/json")]
    public class TouristSpotPhotoController : ApiControllerBase<TouristSpotPhoto>
    {
        public static IWebHostEnvironment _environment;
        private readonly ITouristSpotPhotoService _service;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public TouristSpotPhotoController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ITouristSpotPhotoService service)
            : base(userManager, signInManager, service)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _service = service;
        }
    }
}
