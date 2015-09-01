using DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContract
{
    public interface IStoryDataService
    {
        TaskResult<bool> PostStory(StoryDetail story);
        TaskResult<bool> DeleteById(int id);
        TaskResult<StoryDetail> GetById(int id);
        TaskResult<ICollection<StoryDetail>> GetStoriesByGroup(int GroupId, DataRequest request);
        TaskResult<ICollection<StoryDetail>> GetStoriesByUser(int UserId, DataRequest request);
    }
}
