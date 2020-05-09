using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarStore_WebApplication.Controllers
{
    public class VehicleWebAppController : ApiController
    {
        public string Get()
        {
            return "Hello from the WebApp...";
        }
    }
}
