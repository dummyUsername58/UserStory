using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContract;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Threading;
using ServiceContract;
namespace DataService
{
    public class MVCGroupDataService :ConnectionManager, IGroupDataService
    {
        public TaskResult<IEnumerable<GroupDetail>> GetGroups(DataRequest request)
        {
            TaskResult<IEnumerable<GroupDetail>> result = null;
            HttpClient client = GetHTTPClient();
            var content = new ObjectContent(typeof(DataRequest), request, new JsonMediaTypeFormatter());
            HttpResponseMessage response = client.PostAsync("api/Group/GetGroups", content).Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<TaskResult<IEnumerable<GroupDetail>>>().Result;

            }
            else
            {
                result = new TaskResult<IEnumerable<GroupDetail>> { state = StatusState.CancelState, Data = null };
            }
            return result;
        }

        TaskResult<bool> IGroupDataService.CreateGroup(GroupDetail group)
        {
            TaskResult<bool> result = null;
            HttpClient client = GetHTTPClient();
            var content = new ObjectContent(typeof(GroupDetail), group, new JsonMediaTypeFormatter());
            HttpResponseMessage response = client.PostAsync("api/Group/CreateGroup", content).Result;

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


        public TaskResult<IEnumerable<GroupDetail>> GetGroupsWithDetails(DataRequest request)
        {
            TaskResult<IEnumerable<GroupDetail>> result = null;
            HttpClient client = GetHTTPClient();
            var content = new ObjectContent(typeof(DataRequest), request, new JsonMediaTypeFormatter());
            HttpResponseMessage response = client.PostAsync("api/Group/GetGroupsWithDetails", content).Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<TaskResult<IEnumerable<GroupDetail>>>().Result;

            }
            else
            {
                result = new TaskResult<IEnumerable<GroupDetail>> { state = StatusState.CancelState, Data = null };
            }
            return result;
        }


        public TaskResult<IEnumerable<int>> GetUserGroups(int id)
        {
            TaskResult<IEnumerable<int>> result = null;
            HttpClient client = GetHTTPClient();
            HttpResponseMessage response = client.PostAsync("api/Group/GetGroupsByUser/"+id, null).Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<TaskResult<IEnumerable<int>>>().Result;

            }
            else
            {
                result = new TaskResult<IEnumerable<int>> { state = StatusState.CancelState, Data = null };
            }
            return result;
        }
        public TaskResult<bool> JoinGroup(JoinDetail detail)
        {
            TaskResult<bool> result;
            HttpClient client = GetHTTPClient();
            var content = new ObjectContent(typeof(JoinDetail), detail, new JsonMediaTypeFormatter());
            HttpResponseMessage response = client.PostAsync("api/Group/Join", content).Result;

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
    }
}
