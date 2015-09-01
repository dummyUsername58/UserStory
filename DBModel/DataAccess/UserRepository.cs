using DataContract;
using EntityTypes;
using DataTypes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserRepository:BaseRepository<User>,IUserRepository
    {
        public UserRepository(DbContext dbContext)
            : base(dbContext)
        {

        }

       
       
    }
}
