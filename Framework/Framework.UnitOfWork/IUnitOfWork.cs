using Framework.Framework.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Framework.UnitOfWork
{
    public interface IUnitOfWork<TDbContext> where TDbContext : DbContext
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
        public void SaveChanges();
        public void BeginTransaction();
        public void Commit();
        public void Rollback();
    }
}
