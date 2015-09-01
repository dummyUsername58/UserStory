using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataContract;
namespace ServiceContract
{
    public interface IGroupDataService
    {
        TaskResult<bool> CreateGroup(GroupDetail group);
        TaskResult<IEnumerable<GroupDetail>> GetGroups(DataRequest request);
        TaskResult<IEnumerable<GroupDetail>> GetGroupsWithDetails(DataRequest request);
        TaskResult<IEnumerable<int>> GetUserGroups(int userId);
        TaskResult<bool> JoinGroup(JoinDetail detail);
    }
}
