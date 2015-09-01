using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserStoriesDemo.Models.ViewModels
{
    public class GroupViewModel
    {
        public string Description { get; set; }
        [Required]
        public string Name { get; set; }
        public int? Id { get; set; }
        public int NumberOfStories { get; set; }

        public int NumberOfMembers { get; set; }
    }
}