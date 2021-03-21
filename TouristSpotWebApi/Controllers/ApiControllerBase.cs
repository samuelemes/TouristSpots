using Microsoft.AspNetCore.Mvc;
using Sistema.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using TouristSpotCore.Lib.Http;

namespace TouristSpotWebApi.Controllers
{
    [Produces("application/json")]
    public abstract class ApiControllerBase<TEntity> : Controller
    where TEntity : class//, IEntity
    {
        #region Fields

        private readonly IServiceBase<TEntity> _business;

        #endregion

        #region Constructors

        protected ApiControllerBase(IServiceBase<TEntity> business)
        {
            _business = business;
        }

        #endregion
        
        
        [HttpGet]
        public virtual IActionResult Get()
        {
            // Era assim antes
            //return new ObjectResult(_business.GetAll());
            try
            {
                var result = new ResultBase<IEnumerable<TEntity>>();
                var list = new ObjectResult(_business.GetAll());
                result.Data = (IEnumerable<TEntity>)list.Value;

                return new ObjectResult(result);
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        [HttpGet("{id}", Name = "GetById")]
        public virtual IActionResult Get(int id)
        {
            try
            {
                var result = new ResultBase<TEntity>();
                var item = new ObjectResult(_business.GetById(id));
                result.Data = (TEntity)item.Value;

                return new ObjectResult(result);
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }            
        }

        [HttpPost]
        public virtual IActionResult Create(TEntity model)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _business.Add(model);
            return new ObjectResult(model);
        }

        [HttpPut]
        public virtual IActionResult Update(TEntity model)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _business.Update(model);

            return new ObjectResult(model);
        }
    }
}