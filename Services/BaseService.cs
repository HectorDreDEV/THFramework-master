using Framework.Framework.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class BaseService<TDbContext> where TDbContext : DbContext
    {
        protected IUnitOfWork<TDbContext> UnitOfWork;
        public BaseService(IUnitOfWork<TDbContext> unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
