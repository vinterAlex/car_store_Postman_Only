using CarsStore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace CarStoreApplication.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarController : ControllerBase
    {
        [HttpGet]
        public IActionResult RetrieveCar()
        {
            return Ok("RetrieveCar method [OK]");
        }

        

    }
}
