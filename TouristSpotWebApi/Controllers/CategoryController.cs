using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using TouristSpotsDomain.Entities;
using TouristSpotsDomain.Entities.Security;
using TouristSpotsService.Interfaces;

namespace TouristSpotWebApi.Controllers
{
    [AllowAnonymous]
    public class CategoryController : ApiControllerBase<Category>
    {
        public static IWebHostEnvironment _environment;
        private readonly ICategoryService _service;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public CategoryController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ICategoryService service)
            : base(userManager, signInManager, service)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _service = service;
        }

        public IActionResult Index()
        {
            return null;
        }
    }
}
