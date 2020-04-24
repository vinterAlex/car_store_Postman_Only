using CarsStore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace CarStoreApplication.Controllers
{
    [ApiController]
    [Route("api/getcars")]
    public class CarController : ControllerBase
    {
        

        

        [HttpGet]
        public IActionResult RetrieveCar()
        {
            return Ok("RetrieveCar method [OK]");
        }





    }
}
