﻿
using System.Collections.Generic;

namespace Sistema.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity model);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity model);
        void Remove(TEntity model);
        void Dispose();
    }
}
