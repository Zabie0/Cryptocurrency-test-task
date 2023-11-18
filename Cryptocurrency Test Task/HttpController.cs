using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Cryptocurrency_Test_Task
{
    public class HttpController : ApiController
    {
        private static readonly HttpClient httpClient;

        static HttpController()
        {
            var socketsHandler = new SocketsHttpHandler
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(2)
            };

            httpClient = new HttpClient(socketsHandler);
        }
    }
}
