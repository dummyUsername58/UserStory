using DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContract;
namespace DataManagerContract
{
    public interface IStoryContract
    {
        TaskResult<bool> SaveStory(StoryDetail story);
        TaskResult<bool> DeleteById(int id);
        TaskResult<StoryDetail> GetById(int id);
        TaskResult<IEnumerable<StoryDetail>> GetStoriesForGroupByRequest(int groupId, DataRequest request);
        TaskResult<IEnumerable<StoryDetail>> GetStoriesForUserByRequest(int groupId, DataRequest request);
    }
}
