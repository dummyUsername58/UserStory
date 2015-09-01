using DataTypes;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSource.EntityMapping
{
    class GroupMap:EntityTypeConfiguration<Group>
    {
        public GroupMap()
        {
            Property(g => g.Name).HasMaxLength(30);
            Property(g => g.Description).HasMaxLength(100);
        }
            
    }
}
