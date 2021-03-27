﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using TouristSpotsDomain.Entities;
using TouristSpotsService.Interfaces;

namespace TouristSpotWebApi.Controllers
{
    public class CategoryController : ApiControllerBase<Category>
    {
        public static IWebHostEnvironment _environment;
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service) : base(service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return null;
        }
    }
}
