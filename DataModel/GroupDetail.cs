using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContract
{
    public class GroupDetail
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public int? Id { get; set; }
        public int NumberOfStories { get; set; }

        public int NumberOfMembers { get; set; }
    }
}
