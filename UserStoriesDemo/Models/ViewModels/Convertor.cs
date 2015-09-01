using DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserStoriesDemo.Models.ViewModels
{
    public static class Convertor
    {
        public static StoryDetail ConvertToStoryDetail(this StoryViewModel model)
        {
            return new StoryDetail 
            { 
                Content = model.Content,
                Description = model.Description,
                GroupDetails = model.GroupDetails ==null?null:model.GroupDetails.Select(a => a.ConvertToGroupDetail()).AsEnumerable(),
                Id = model.Id, 
                PostedOn = model.PostedOn,
                Title = model.Title,
                UserId = model.UserId 
            };
        }
        public static StoryViewModel ConvertToStoryViewModel(this StoryDetail model)
        {

            return new StoryViewModel 
            { 
                Content = model.Content, 
                Description = model.Description,
                GroupDetails = model.GroupDetails.Select(a => a.ConvertToGroupViewModel()).AsEnumerable(),
                Id = model.Id, 
                PostedOn = model.PostedOn,
                Title = model.Title, 
                UserId = model.UserId 
            };
        }
        public static GroupDetail ConvertToGroupDetail(this GroupViewModel model)
        {
            return new GroupDetail {Description=model.Description,Id=model.Id,Name=model.Name,NumberOfMembers=model.NumberOfMembers,NumberOfStories=model.NumberOfStories };
        }
        public static GroupViewModel ConvertToGroupViewModel(this GroupDetail model)
        {
            return new GroupViewModel {Description=model.Description,Id=model.Id,Name=model.Name,NumberOfMembers=model.NumberOfMembers,NumberOfStories=model.NumberOfStories };
        }
    }
}