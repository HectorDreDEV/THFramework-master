using Framework.Framework.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Framework.UnitOfWork
{
    public class UnitOfWork<TDbContext> : IUnitOfWork<TDbContext> where TDbContext : DbContext
    {
        protected TDbContext Context;

        private readonly IServiceProvider _serviceProvider;
        public UnitOfWork(TDbContext context, IServiceProvider serviceProvider)
        {
            Context = context;
            _serviceProvider = serviceProvider;
        }
        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public DatabaseFacade Database => Context.Database;
        public IDbContextTransaction Transaction { get; set; }
        public void BeginTransaction() 
        {
            Transaction = Database.BeginTransaction();
        }  
        public void Commit() => Transaction.Commit();
        public void Rollback() => Transaction.Rollback();

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            return _serviceProvider.GetService<IRepository<TEntity>>();
        }
    }
}
