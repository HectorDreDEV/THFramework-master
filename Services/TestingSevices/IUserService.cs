using CoreData.DbContexts;
using CoreData.Entities.EfEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.TestingSevices
{
    public interface IUserService : ITestService<EFDbContext>
    {
        IList<UserEntity> Get();
        void AddUser();
    }
}
