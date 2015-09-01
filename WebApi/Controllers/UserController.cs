using DataManagerContract;
using DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class UserController : BaseApiController
    {
        IUserContract _userManager;
        public UserController(IUserContract userContract)
        {
            _userManager = userContract;
        }
        [HttpPost]
        public TaskResult<UserDetail> Validate([FromBody] UserDetail user)
        {
            return _userManager.Validate(user);
        }
        [HttpPost]
        public TaskResult<bool> Save([FromBody] UserDetail user)
        {
            return _userManager.SaveUser(user);
        }
       
        [HttpPost]
        public TaskResult<UserDetail> GetDetail([FromBody] int id)
        {
            return _userManager.GetUserDetails(id);
        }
         [HttpPost]
        public TaskResult<UserDetail> GetDetailByName([FromBody] string name)
        {
            return _userManager.GetUserDetails(name);
        }
        
    }
}
