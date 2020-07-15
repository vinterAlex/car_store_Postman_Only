
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Models;
using CarStoreApplication.Methods;

namespace CarStoreApplication.Controllers
{
    




    [ApiController]
    [Route("api/shop/[controller]")]
    public class VehicleController : ControllerBase
    {
        VehicleMethods methods = new VehicleMethods();


        [HttpGet]
        public  IActionResult GetVehicles()
        {
            var result = methods.RetrieveVehicles();
            return Ok(result);
        }

        [HttpGet("{vehicleIDParam}")]
        public  IActionResult GetVehicleById(int vehicleIDParam)
        {
            var result = methods.RetrieveVehicleById(vehicleIDParam);
            
            return Ok(result);

        }

        [HttpGet("vehiclebyyear")]
        public IActionResult GetVehicleByYear(int year)
        {
            return Ok(methods.GetVehicleByYear(year));
        }

        [HttpGet("vehiclebymake")]
        public IActionResult GetVehicleByMake(string make)
        {
            return Ok(methods.GetVehicleByMake(make));
        }


        [HttpPost("createvehicle")]
        public IActionResult AddNewVehicle([FromBody] CreateVehicle vItem)
        {
            var result = methods.AddNewVehicle(vItem);
            
            return Ok(result);
        }

        [HttpPut("updatevehicle")]
        public  IActionResult UpdateVehicle(int vehicleID, [FromBody]CreateVehicle updateVehicleItem)
        {
            var result =  methods.UpdateVehicle(vehicleID,updateVehicleItem);

            return Ok(result);
        }

        [HttpDelete("deletevehicle")]
        public IActionResult DeleteVehicle(int vehicleID)
        {
            
            return Ok(methods.DeleteVehicle(vehicleID)) ;
        }

        /// <summary>
        /// Get Vehicle by Year
        /// </summary>





    }
}
