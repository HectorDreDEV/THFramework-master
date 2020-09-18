using System;
using System.Collections.Generic;
using System.Text;

namespace CoreData.Entities.EfEntity
{
    public class UserEntity : EFBaseEntity, IBaseEntity
    {
        public string Name { get; set; }
    }
}
