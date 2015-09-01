using DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagerContract
{
    public interface IGroupContract
    {
        TaskResult<bool> SaveGroup(GroupDetail group);
        TaskResult<bool> DeleteById(int id);
        TaskResult<IEnumerable<GroupDetail>> GetGroupsByRequest(DataRequest request);
        TaskResult<IEnumerable<GroupDetail>> GetGroupsWithDetail(DataRequest request);
        TaskResult<IEnumerable<int>> GetUserGroups(int userId);
        TaskResult<bool> JoinGroup(JoinDetail jdetail);
    }
}
