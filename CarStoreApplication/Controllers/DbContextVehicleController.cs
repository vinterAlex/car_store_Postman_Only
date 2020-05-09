using CarsStore;
using CarStoreApplication.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CarStoreApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DbContextVehicleController : ControllerBase
    {
        private readonly VehiclesDBContext _context;

        public DbContextVehicleController (VehiclesDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetVehicles()
        {
            return Ok(_context.VehiclesDbSet.ToList());
        }

        [HttpGet("{vehicleID}")]
        public IActionResult GetVehicleByID(int vehicleID)
        {
            return Ok(_context.VehiclesDbSet.Where(c => c.VehicleID == vehicleID).ToList());
        }

        //[HttpGet]
        //public IEnumerable<Vehicles> GetCar()
        //{
        //    return _context.VehiclesDbSet.ToList();
        //    
        //}


    }
}
