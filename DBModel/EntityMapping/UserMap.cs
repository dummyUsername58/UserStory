using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using DataTypes;

namespace DBSource.EntityMapping
{
    class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            Property(u =>u.UserName).IsRequired();
            Property(u => u.Password).IsRequired();

        }
    }
}
