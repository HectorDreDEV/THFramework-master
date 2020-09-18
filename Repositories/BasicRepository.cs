using Framework.Framework.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class BasicRepository<TEntity, TDbContext> : EfRepository<TEntity, TDbContext>, IRepository<TEntity>
        where TEntity : class
        where TDbContext : DbContext
    {

        public BasicRepository()
        {

        }
    }
}
