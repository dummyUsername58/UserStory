using DataContract;
using DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTypes
{
   public interface IStoryRepository:IRepository<Story>
    {
       void AddStoryToGroups(Story storyId, IEnumerable<int> groupIds);
       IEnumerable<Story> GetStoriesForGroup(int groupId, DataRequest request);
       IEnumerable<Story> GetStoriesForUser(int userId, DataRequest request);
    }
}
