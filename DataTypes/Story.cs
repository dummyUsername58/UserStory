using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    public class Story:BaseModel
    {
        public Story()
        { /*Groups = new HashSet<Group>();*/ }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
