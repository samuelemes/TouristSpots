using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TouristSpotCore.Lib.Http;
using TouristSpotsDomain.Entities;
using TouristSpotsDomain.Entities.Security;
using TouristSpotsService.Interfaces;

namespace TouristSpotWebApi.Controllers
{
    public class FavoriteTouristSpotController : ApiControllerBase<FavoriteTouristSpot>
    {
        public static IWebHostEnvironment _environment;
        private readonly IFavoriteTouristSpotService _service;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public FavoriteTouristSpotController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IFavoriteTouristSpotService service)
            : base(userManager, signInManager, service)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _service = service;
        }

        public IActionResult GetByUser(int id)
        {
            try
            {
                var result = new ResultBase<IEnumerable<FavoriteTouristSpot>>();

                result.Success = true;
                result.Data = _service.getByUser(id);

                return new ObjectResult(result);
            }
            catch (Exception erro)
            {
                var result = new ResultBase<IEnumerable<FavoriteTouristSpot>>();
                result.Success = false;
                throw new Exception(erro.Message);
            }
        }

    }
}
