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
    public class TouristSpotController : ApiControllerBase<TouristSpot>
    {
        public static IWebHostEnvironment _environment;
        private readonly ITouristSpotService _service;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public TouristSpotController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ITouristSpotService service)
            : base(userManager, signInManager, service)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _service = service;
        }

        [HttpPost]
        public override IActionResult Create([FromHeader] AppUser user, [FromBody] TouristSpot model)
        {
            var result = new ResultBase<TouristSpot>();
            try
            {
                _service.Create(model);
                result.Success = true;
                result.Data = model;

                return new ObjectResult(model);
            }
            catch (Exception erro)
            {
                result.Success = false;
                result.Exception = new Exception(erro.InnerException.Message);

                return new ObjectResult(result);
            }
        }

        public IActionResult GetByFilter([FromBody] TouristSpot filter)
        {
            try
            {
                var result = new ResultBase<IEnumerable<TouristSpot>>();

                result.Success = true;
                result.Data = _service.GetByName(filter);

                return new ObjectResult(result);
            }
            catch (Exception erro)
            {
                var result = new ResultBase<IEnumerable<TouristSpot>>();
                result.Success = false;
                throw new Exception(erro.Message);
            }            
        }
    }
}
