using DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserStoriesDemo.Models.ViewModels;
using ServiceContract;
namespace UserStoriesDemo.Controllers
{
    [Authorize]
    public class GroupController : BaseController
    {
        public GroupController(IGroupDataService service, IUserDataService uservice)
        {
            groupDataService = service;
            userDataService = uservice;
        }
        // GET: Group
        public ActionResult Index()
        {
           var modelRequest = groupDataService.GetGroupsWithDetails(new DataRequest { Count = 100, StartPosition = 0 });
           IEnumerable<GroupViewModel> model =new GroupViewModel[0];
           if (modelRequest.state == StatusState.DoneState)
            {
                TaskResult<IEnumerable<int>> getGroupTask = groupDataService.GetUserGroups(UserDetails.Id.Value);
                if (getGroupTask.state == StatusState.DoneState)
                {
                    if (getGroupTask.Data != null)
                    {
                        ViewBag.UserGroups = getGroupTask.Data.ToList();
                    }
                    else
                    {
                        ViewBag.UserGroups = new List<int>();
                    }
                }
                else//error handle 
                {

                }
                model = modelRequest.Data.Select(a => a.ConvertToGroupViewModel()).AsEnumerable();
            }

           
          
          
          return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(GroupViewModel saveViewModel)
        {
            if(ModelState.IsValid)
            {
                groupDataService.CreateGroup(saveViewModel.ConvertToGroupDetail());
            }
            else
            {
                return View();
            }
            
            return RedirectToAction("Index");
        }
        public ActionResult JoinGroup(int id)
        {
            groupDataService.JoinGroup(new JoinDetail { GroupId = id, UserId = UserDetails.Id.Value });
            return RedirectToAction("Index");
        }

    }
}