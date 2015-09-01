using DataContract;
using ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserStoriesDemo.Models.ViewModels;

namespace UserStoriesDemo.Controllers
{
    [Authorize]
    public class StoryController : BaseController
    {
        public StoryController(IStoryDataService service,IUserDataService uservice,IGroupDataService gDataService)
        {
            storyDataService = service;
            userDataService = uservice;
            groupDataService = gDataService;
        }
        // GET: Story
        public ActionResult Index()
        {
            var storyRequest = storyDataService.GetStoriesByUser(UserDetails.Id.Value, new DataRequest { StartPosition=0,Count=50});
            IEnumerable<StoryViewModel> model= new StoryViewModel[0];
            if(storyRequest.Data!=null)
            {
                model = storyRequest.Data.Select(a => a.ConvertToStoryViewModel()).ToList();
            }
            return View(model);
        }
        public ActionResult Create()
        {
            StoryViewModel model = new StoryViewModel();
            TaskResult<IEnumerable<GroupDetail>> groupDetailRequest =groupDataService.GetGroups(new DataRequest { StartPosition = 0, Count = 100 });
            if(groupDetailRequest.Data!=null)
            {
                model.AllGroups = groupDetailRequest.Data.Select(a => a.ConvertToGroupViewModel());
            }
           
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(StoryViewModel model, int[] selectedItems)
        {
            if(model.Title==null)//Invalid Model State, dirty approach
            {
                return View(model);
            }
            int[] items = selectedItems;
            if (selectedItems == null)
            {
                items = new int[0];
            }
            StoryDetail detail = model.ConvertToStoryDetail();
            detail.UserId = UserDetails.Id;
            detail.GroupDetails = items.Select(a => new GroupDetail { Id = a });
            storyDataService.PostStory(detail);
            return RedirectToAction("Index");
        }
        public ActionResult ViewStory(StoryViewModel story)
        {

            return View(story);
        }
        [HttpGet]
        public ActionResult EditStory(int id)
        {
          StoryViewModel model =  storyDataService.GetById(id).Data.ConvertToStoryViewModel();
         ;
         TaskResult<IEnumerable<GroupDetail>> groupDetailRequest = groupDataService.GetGroups(new DataRequest { StartPosition = 0, Count = 100 });
         if (groupDetailRequest.Data != null)
         {
             model.AllGroups = groupDetailRequest.Data.Select(a => a.ConvertToGroupViewModel());
         }
          return View(model);
        }
        [HttpPost]
        public ActionResult EditStory(StoryViewModel model, int[] selectedItems)
        {
            StoryDetail detail = model.ConvertToStoryDetail();
            int[] items = selectedItems;
            if(selectedItems==null)
            {
                items = new int[0];
            }
            if (model.Title == null)//Invalid Model State, dirty approach
            {
                model.AllGroups= new GroupViewModel[0];
                TaskResult<IEnumerable<GroupDetail>> groupDetailRequest = groupDataService.GetGroups(new DataRequest { StartPosition = 0, Count = 100 });
                if (groupDetailRequest.Data != null)
                {
                    model.AllGroups = groupDetailRequest.Data.Select(a => a.ConvertToGroupViewModel());
                }
                return View(model);
            }
            detail.GroupDetails = items.Select(a => new GroupDetail { Id = a });
            storyDataService.PostStory(detail);
            return RedirectToAction("Index");
        }

    }
}