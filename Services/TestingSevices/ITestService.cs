using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.TestingSevices
{
    public interface ITestService<TDbContext> where TDbContext : DbContext
    {

    }
}
