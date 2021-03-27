using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using TouristSpotsDomain.Entities;
using TouristSpotsService.Interfaces;

namespace TouristSpotWebApi.Controllers
{
    [Produces("application/json")]
    public class TouristSpotPhotoController : ApiControllerBase<TouristSpotPhoto>
    {
        public static IWebHostEnvironment _environment;
        private readonly ITouristSpotPhotoService _service;

        public TouristSpotPhotoController(ITouristSpotPhotoService service) : base(service)
        {
            _service = service;
        }
    }
}
