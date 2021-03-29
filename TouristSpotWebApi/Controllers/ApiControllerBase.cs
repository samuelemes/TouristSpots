using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sistema.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using TouristSpotCore.Lib.Http;
using TouristSpotsDomain.Entities.Security;

namespace TouristSpotWebApi.Controllers
{
    [Produces("application/json")]
    //[Authorize]
    [AllowAnonymous]
    public abstract class ApiControllerBase<TEntity> : ControllerBase
    where TEntity : class//, IEntity
    {
        #region Fields

            private readonly IServiceBase<TEntity> _business;
            private readonly UserManager<AppUser> _userManager;
            private readonly SignInManager<AppUser> _signInManager;

        #endregion

        #region Constructors

        protected ApiControllerBase(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager, 
            IServiceBase<TEntity> business)
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _business = business;
            }

        #endregion
        
        
        [HttpGet]
        [AllowAnonymous]
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
        [Authorize]
        public virtual IActionResult Create([FromHeader] AppUser user, [FromBody] TEntity model)
        {
            var result = new ResultBase<TEntity>();
            try
            {
                var singin = _signInManager.PasswordSignInAsync(user.Email, user.PasswordHash, false, false);

                if (!singin.IsCompletedSuccessfully)
                {
                    _business.Add(model);
                    result.Success = true;
                    result.Data = model;
                } else {
                    result.Success = false;
                    result.Exception = new Exception("Invalid Login Attemp");
                }
            }
            catch (Exception erro)
            {
                result.Success = false;
                result.Exception = new Exception(erro.InnerException.Message);
            }

            return new ObjectResult(result);
        }

        [HttpPut]
        [Authorize]
        public virtual IActionResult Update(TEntity model)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _business.Update(model);

            return new ObjectResult(model);
        }

        [HttpDelete]
        [Authorize]
        public virtual IActionResult Delete(int id)
        {
            var result = new ResultBase<TEntity>();
            try
            {
                var item = new ObjectResult(_business.GetById(id));
                result.Success = true;
                _business.Remove((TEntity)item.Value);

                return new ObjectResult(result);
            }
            catch (Exception erro)
            {
                result.Success = false;
                result.Exception = new Exception(erro.InnerException.Message);
                return new ObjectResult(result);
            }
        }
    }
}