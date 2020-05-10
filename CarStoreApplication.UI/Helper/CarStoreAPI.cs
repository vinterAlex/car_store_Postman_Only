using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CarStoreApplication.UI.Helper
{
    public class CarStoreAPI
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:51680/");
            

            return client;
        }
    }
}
