using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using TouristSpotCore.Lib.Http;
using TouristSpotsDomain.Entities.Security;
using TouristSpotsService.Interfaces;
using TouristSpotWebApi.Controllers;

namespace TouristSpotsApi.Controllers
{
    public class LoginController : ApiControllerBase<AppUser>
    {
        public static IWebHostEnvironment _environment;
        private readonly IUserService _service;

        public LoginController(IUserService service) : base(service)
        {
            _service = service;
        }
    }
}
