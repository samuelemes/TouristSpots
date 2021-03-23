using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TouristSpotsDomain.Interface.Repositories;

namespace TouristSpotsData.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        private static DbContextOptions<AppDbContext> _options;

        protected AppDbContext DbContext = new AppDbContext();
        public void Add(TEntity model)
        {
            DbContext.Set<TEntity>().Add(model);
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            //this.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return DbContext.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity model)
        {
            DbContext.Set<TEntity>().Remove(model);
            DbContext.SaveChanges();
        }

        public void Update(TEntity model)
        {
            DbContext.Entry(model).State = EntityState.Modified;
            DbContext.SaveChanges();
        }
    }
}
