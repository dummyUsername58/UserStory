using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTypes;
using DataContract;
namespace EntityTypes
{
    public interface IGroupRepository:IRepository<Group>
    {
        IEnumerable<Group> GetGroupsByStoryId(int storyId);
        IEnumerable<Group> GetGroupsByRequest(DataRequest request);
        IEnumerable<GroupDetail> GetGroupsWithDetailsByRequest(DataRequest request);
        IEnumerable<Group> GetGroupsByUserId(int userId);
        void JoinGroup(JoinDetail jdetail);

    }
}
