﻿using System.Collections.Generic;

namespace TouristSpotsDomain.Interface.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity model);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity model);
        void Remove(TEntity model);
        void Dispose();
    }
}