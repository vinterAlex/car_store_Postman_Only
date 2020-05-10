using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarStoreApplication.UI.Models;
using CarStoreApplication;
using VehicleUtils;
using System.Net.Http;
using CarStoreApplication.UI.Helper;
using Newtonsoft.Json;

namespace CarStoreApplication.UI.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //CarStoreAPI _api = new CarStoreAPI();
        //public async Task<IActionResult> Vehicles()
        //{
        //    List<Vehicles> vehiclesList = new List<Vehicles>();
        //
        //    HttpClient client = _api.Initial();
        //
        //    HttpResponseMessage res = await client.GetAsync("api/shop/vehicle");
        //
        //    if (res.IsSuccessStatusCode)
        //    {
        //        var result = res.Content.ReadAsStringAsync().Result;
        //
        //        vehiclesList = JsonConvert.DeserializeObject<List<Vehicles>>(result);
        //    }
        //
        //
        //    return View(vehiclesList);
        //}

    }
}
