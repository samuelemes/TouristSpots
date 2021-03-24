﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TouristSpotCore.Lib.Http;
using TouristSpotsDomain.Entities;
using TouristSpotsService.Interfaces;

namespace TouristSpotWebApi.Controllers
{
    public class TouristSpotController : ApiControllerBase<TouristSpot>
    {
        public static IWebHostEnvironment _environment;
        private readonly ITouristSpotService _service;

        public TouristSpotController(ITouristSpotService service) : base(service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("{model}")]
        [Consumes("application/json")]
        public ActionResult BuscarPais([FromBody] TouristSpot filter)
        {
            var result = new ResultBase<IEnumerable<TouristSpot>>();
            result.Data = _service.GetByName(filter);

            return new ObjectResult(result);
        }
    }
}
