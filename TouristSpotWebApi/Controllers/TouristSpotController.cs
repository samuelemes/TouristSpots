using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Sistema.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using TouristSpotCore.Lib.Http;
using TouristSpotsData.Repositories;
using TouristSpotsDomain.Entities;
using TouristSpotsDomain.Interface.Repositories;
using TouristSpotsService;
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
