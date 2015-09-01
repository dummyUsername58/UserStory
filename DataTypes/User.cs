using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    public class User:BaseModel
    {
        public User() { /*UserGroups = new HashSet<Group>(); Stories = new HashSet<Story>();*/ }
        public string UserName { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Group> UserGroups { get; set; }
        public virtual ICollection<Story> Stories { get; set; }
    }
}
