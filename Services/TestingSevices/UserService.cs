using CoreData.DbContexts;
using CoreData.Entities.EfEntity;
using Framework.Framework.Repository;
using Framework.Framework.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.TestingSevices
{
    public class UserService : BaseService<EFDbContext>, IUserService
    {
        IRepository<UserEntity> _userRepo;
        public UserService(IUnitOfWork<EFDbContext> unitOfWork, IRepository<UserEntity> user):
            base(unitOfWork)
        {
            _userRepo = user;
        }

        public IList<UserEntity> Get()
        {
            var result = _userRepo.GetAll().ToList();
            return result;
        }

        public void AddUser()
        {
            var user = new UserEntity()
            {
                Name = "test"
            };

            _userRepo.Add(user);
            UnitOfWork.SaveChanges();
        }
    }
}
