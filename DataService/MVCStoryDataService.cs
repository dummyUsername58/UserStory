using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using ServiceContract;
using DataContract;
namespace DataService
{
    public class MVCStoryDataService:ConnectionManager,IStoryDataService
    {
        public TaskResult<ICollection<StoryDetail>> GetStoriesByGroup(int GroupId, DataRequest request)
        {
            TaskResult<ICollection<StoryDetail>> result = null;
            HttpClient client = GetHTTPClient();
            var wrappedRequest= new RequestWrapper { Id = GroupId, request = request };
            var content = new ObjectContent(typeof(RequestWrapper), wrappedRequest, new JsonMediaTypeFormatter());
            HttpResponseMessage response = client.PostAsync("api/Story/GetStoriesByGroup", content).Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<TaskResult<ICollection<StoryDetail>>>().Result;

            }
            else
            {
                result = new TaskResult<ICollection<StoryDetail>> { state = StatusState.CancelState, Data = null };
            }
            return result;
        }

        TaskResult<bool> IStoryDataService.PostStory(StoryDetail story)
        {
            TaskResult<bool> result;
            HttpClient client = GetHTTPClient();
            var content = new ObjectContent(typeof(StoryDetail), story, new JsonMediaTypeFormatter());
            HttpResponseMessage response = client.PostAsync("api/Story/PostStory", content).Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<TaskResult<bool>>().Result;

            }
            else
            {
                result = new TaskResult<bool> { state = StatusState.CancelState, Data = false };
            }
            return result;
        }

        public TaskResult<bool> DeleteById(int id)
        {
            TaskResult<bool> result;
            HttpClient client = GetHTTPClient();
            var content = new ObjectContent(typeof(int), id, new JsonMediaTypeFormatter());
            HttpResponseMessage response = client.PostAsync("api/Story/DeleteById", content).Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<TaskResult<bool>>().Result;

            }
            else
            {
                result = new TaskResult<bool> { state = StatusState.CancelState, Data = false };
            }
            return result;
        }


        public TaskResult<ICollection<StoryDetail>> GetStoriesByUser(int UserId, DataRequest request)
        {
            TaskResult<ICollection<StoryDetail>> result = null;
            HttpClient client = GetHTTPClient();
            var wrappedRequest = new RequestWrapper { Id = UserId, request = request };
            var content = new ObjectContent(typeof(RequestWrapper), wrappedRequest, new JsonMediaTypeFormatter());
            HttpResponseMessage response = client.PostAsync("api/Story/GetStoriesByUser", content).Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<TaskResult<ICollection<StoryDetail>>>().Result;

            }
            else
            {
                result = new TaskResult<ICollection<StoryDetail>> { state = StatusState.CancelState, Data = null };
            }
            return result;
        }


        public TaskResult<StoryDetail> GetById(int id)
        {
            TaskResult<StoryDetail> result;
            HttpClient client = GetHTTPClient();
            var content = new ObjectContent(typeof(int), id, new JsonMediaTypeFormatter());
            HttpResponseMessage response = client.PostAsync("api/Story/GetById", content).Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<TaskResult<StoryDetail>>().Result;

            }
            else
            {
                result = new TaskResult<StoryDetail> { state = StatusState.CancelState, Data = null };
            }
            return result;
        }
    }
}
