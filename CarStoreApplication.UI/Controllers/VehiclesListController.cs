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
    public class VehiclesListController : Controller
    {
        CarStoreAPI _api = new CarStoreAPI();
        public async Task<IActionResult> Vehicles()
        {
            List<Vehicles> vehiclesList = new List<Vehicles>();

            HttpClient client = _api.Initial();

            HttpResponseMessage res = await client.GetAsync("api/shop/vehicle"); // to get all the vehicles

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;

                vehiclesList = JsonConvert.DeserializeObject<List<Vehicles>>(result);
            }


            return View(vehiclesList);
        }
    }
}
