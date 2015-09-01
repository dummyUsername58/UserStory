using ServiceContract;
using DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
namespace DataService
{
    public class MVCUserDataService:ConnectionManager,IUserDataService
    {
        public TaskResult<bool> SaveUser(UserDetail user)
        {
            TaskResult<bool> result;
            HttpClient client = GetHTTPClient();
            var content = new ObjectContent(typeof(UserDetail), user, new JsonMediaTypeFormatter());
            HttpResponseMessage response = client.PostAsync("api/User/Save", content).Result;

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

        


        public TaskResult<UserDetail> TryLoginUser(UserDetail user)
        {
            TaskResult<UserDetail> result=null;
            HttpClient client = GetHTTPClient();
            var content = new ObjectContent(typeof(UserDetail),user, new JsonMediaTypeFormatter());
            HttpResponseMessage response = client.PostAsync("api/User/Validate",content).Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<TaskResult<UserDetail>>().Result;
                  
            }
            else
            {
                result = new TaskResult<UserDetail> { state = StatusState.CancelState, Data = null };
            }
            return result;
        }


        public TaskResult<UserDetail> GetUserDetail(uint id)
        {
            TaskResult<UserDetail> result;
            HttpClient client = GetHTTPClient();
            var content = new ObjectContent(typeof(int), id, new JsonMediaTypeFormatter());
            HttpResponseMessage response = client.PostAsync("api/User/GetDetail", content).Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<TaskResult<UserDetail>>().Result;

            }
            else
            {
                result = new TaskResult<UserDetail> { state = StatusState.CancelState, Data = null };
            }
            return result;
        }


        public TaskResult<UserDetail> GetUserDetail(string name)
        {
            TaskResult<UserDetail> result;
            HttpClient client = GetHTTPClient();
            var content = new ObjectContent(typeof(string), name, new JsonMediaTypeFormatter());
            HttpResponseMessage response = client.PostAsync("api/User/GetDetailByName", content).Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<TaskResult<UserDetail>>().Result;

            }
            else
            {
                result = new TaskResult<UserDetail> { state = StatusState.CancelState, Data = null };
            }
            return result;
        }
    }
}
