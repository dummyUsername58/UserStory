using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    public class Group:BaseModel
    {
        public Group()
        {
          /*  Stories = new HashSet<Story>();
            Users = new HashSet<User>();*/
        }
        public string Description { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Story> Stories { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
