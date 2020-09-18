using Framework.Framework.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IBaseService<TDbContext> where TDbContext : DbContext
    {

    }
}
