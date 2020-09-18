using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Framework.Framework.Repository
{
    public class EfRepository<TEntity, TDbContext> : IRepository<TEntity>
        where TEntity : class
        where TDbContext : DbContext
    {
        protected readonly TDbContext Context;
        protected readonly DbSet<TEntity> Table = null;

        public EfRepository(TDbContext context)
        {
            Context = context;
            Table = Context.Set<TEntity>();
        }

        public TEntity Get(int id)
        {
            // Here we are working with a DbContext, not PlutoContext. So we don't have DbSets 
            // such as Courses or Authors, and we need to use the generic Set() method to access them.
            return Table.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            // Note that here I've repeated Context.Set<TEntity>() in every method and this is causing
            // too much noise. I could get a reference to the DbSet returned from this method in the 
            // constructor and store it in a private field like _entities. This way, the implementation
            // of our methods would be cleaner:
            // 
            // _entities.ToList();
            // _entities.Where();
            // _entities.SingleOrDefault();
            // 
            // I didn't change it because I wanted the code to look like the videos. But feel free to change
            // this on your own.
            return Table.AsNoTracking().ToList();
        }

        public IQueryable<TEntity> GetAllQuery()
        {
            return Table.AsNoTracking().AsQueryable();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Table.AsNoTracking().Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Table.SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            Table.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            //Context.Set<TEntity>().Attach(entity);
            //Context.Entry(entity).State = EntityState.Modified;
            Table.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            TEntity item = Table.Find(id);
            if (item != null)
            {
                Table.Remove(item);
            }
        }

        public void Remove(TEntity entity)
        {
            Table.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Table.RemoveRange(entities);
        }


    }
}
