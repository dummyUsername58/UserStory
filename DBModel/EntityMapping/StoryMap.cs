using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using DataTypes;
namespace DBSource.EntityMapping
{
    class StoryMap:EntityTypeConfiguration<Story>
    {
        public StoryMap()
        {
            Property(s => s.Title).IsRequired();
            Property(s => s.Description);
            Property(s => s.Content).IsRequired();
        }
    }
}
