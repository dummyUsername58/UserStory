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
    public class StoryController : BaseApiController
    {
        readonly IStoryContract _storyManager;
        public StoryController(IStoryContract storyContract)
        {
            _storyManager = storyContract;
        }
        [HttpPost]
        public TaskResult<bool> PostStory([FromBody]StoryDetail story)
        {
            return _storyManager.SaveStory(story);
        }
        [HttpPost]
        public TaskResult<bool> DeleteById([FromBody]int id)
        {
            return _storyManager.DeleteById(id);
        }
         [HttpPost]
        public TaskResult<StoryDetail> GetById([FromBody]int id)
        {
            return _storyManager.GetById(id);
        }
        
        [HttpPost]
        public TaskResult<IEnumerable<StoryDetail>> GetStoriesByGroup([FromBody] RequestWrapper wrappedRequest)
        {
            return _storyManager.GetStoriesForGroupByRequest(wrappedRequest.Id, wrappedRequest.request);
        }
        [HttpPost]
        public TaskResult<IEnumerable<StoryDetail>> GetStoriesByUser([FromBody] RequestWrapper wrappedRequest)
        {
            return _storyManager.GetStoriesForUserByRequest(wrappedRequest.Id, wrappedRequest.request);
        }
    }
}
