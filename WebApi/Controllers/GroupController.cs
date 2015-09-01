using DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataManagerContract;

namespace WebApi.Controllers
{
    public class GroupController : BaseApiController
    {
        private readonly IGroupContract _groupManager;
        public GroupController(IGroupContract groupContract)
        {
            _groupManager = groupContract;
        }
        [HttpPost]
        public TaskResult<bool> CreateGroup([FromBody]GroupDetail detail)
        {
            return _groupManager.SaveGroup(detail);
        }
        [HttpPost]
        public TaskResult<IEnumerable<GroupDetail>> GetGroupsWithDetails([FromBody]DataRequest request)
        {
            return _groupManager.GetGroupsWithDetail(request);
        }
        [HttpPost]
        public TaskResult<IEnumerable<GroupDetail>> GetGroups([FromBody]DataRequest request)
        {
            return _groupManager.GetGroupsByRequest(request);
        }
         [HttpPost]
        public TaskResult<IEnumerable<int>> GetGroupsByUser(int id)
        {
            return _groupManager.GetUserGroups(id);
        }

         [HttpPost]
         public TaskResult<bool> Join([FromBody] JoinDetail detail)
         {
             return _groupManager.JoinGroup(detail);
         }
    }
}
