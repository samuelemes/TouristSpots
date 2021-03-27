using Microsoft.AspNetCore.Mvc;
using Sistema.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using TouristSpotCore.Lib.Http;

namespace TouristSpotWebApi.Controllers
{
    [Produces("application/json")]
    public abstract class ApiControllerBase<TEntity> : ControllerBase
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
            try
            {
                var result = new ResultBase<IEnumerable<TEntity>>();
                var list = new ObjectResult(_business.GetAll());

                if (list == null)
                {
                    result.Success = false;
                    result.Data = null;
                    return new ObjectResult(result);
                } else {
                    result.Data = (IEnumerable<TEntity>)list.Value;

                    result.Success = true;
                    return new ObjectResult(result);
                }

            }
            catch (Exception erro)
            {
                var result = new ResultBase<IEnumerable<TEntity>>();
                result.Success = false;
                throw new Exception(erro.Message);
            }
        }

        [HttpGet("{id}", Name = "GetById")]
        public virtual IActionResult Get(int id)
        {
            var result = new ResultBase<TEntity>();
            try
            {
                var item = new ObjectResult(_business.GetById(id));

                if (item == null)
                {
                    result.Success = false;
                    result.Data = null;
                    return new ObjectResult(result);
                }
                else
                {
                    result.Data = (TEntity)item.Value;
                    result.Success = true;
                    return new ObjectResult(result);
                }

            }
            catch (Exception erro)
            {
                result.Success = false;
                throw new Exception(erro.Message);
            }   
        }

        [HttpPost]
        public virtual IActionResult Create([FromBody] TEntity model)
        {
            var result = new ResultBase<TEntity>();

            try
            {
                _business.Add(model);
                result.Success = true;

                return new ObjectResult(result);
            }
            catch (Exception erro)
            {
                result.Success = false;
                result.Exception = new Exception(erro.InnerException.Message);
                return new ObjectResult(result);
            }
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