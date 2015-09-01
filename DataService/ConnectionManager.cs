using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public abstract class ConnectionManager
    {
        public HttpClient GetHTTPClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:7337/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
