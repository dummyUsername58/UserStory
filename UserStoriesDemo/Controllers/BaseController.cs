using DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ServiceContract;
namespace UserStoriesDemo.Controllers
{
    public class BaseController : Controller
    {
        protected IGroupDataService groupDataService;
        protected IUserDataService userDataService;
        protected IStoryDataService storyDataService;
        protected UserDetail UserDetails
        {
            get
            {
                if(Session["userDetails"] == null)
                {
                   if(Request.IsAuthenticated)
                   {
                       TaskResult<UserDetail> userDetail = userDataService.GetUserDetail(User.Identity.Name);
                       if(userDetail.Data!=null)
                       {
                           Session["userDetails"]= userDetail.Data;
                       }
                      
                   }
                   else
                   {
                       Response.Redirect("~/Account/Login");
                   }
                       
                }
                return Session["userDetails"] as UserDetail;
            }
            set
            {
                Session["userDetails"] = value;
            }
        }
    }
}