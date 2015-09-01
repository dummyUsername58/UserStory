using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContract
{
    public class StoryDetail
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Description { get; set; }

        public int? UserId { get; set; }

        public IEnumerable<GroupDetail> GroupDetails { get; set; }

        public DateTime PostedOn { get; set; }

        public int? Id { get; set; }
    }
}
