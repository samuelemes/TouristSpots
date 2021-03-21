﻿using Sistema.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using TouristSpotsDomain.Interface.Repositories;

namespace TouristSpotsService
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }
        public void Add(TEntity model)
        {
            _repository.Add(model);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(TEntity model)
        {
            _repository.Remove(model);
        }

        public void Update(TEntity model)
        {
            _repository.Update(model);
        }
    }
}
