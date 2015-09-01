using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserStoriesDemo.Models.ViewModels
{
    public class StoryViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

        public string Description { get; set; }

        public int? UserId { get; set; }

        public IEnumerable<GroupViewModel> GroupDetails { get; set; }
        public IEnumerable<GroupViewModel> AllGroups { get; set; }

        public DateTime PostedOn { get; set; }

        public int? Id { get; set; }
    }
}