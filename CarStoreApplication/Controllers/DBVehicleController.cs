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
    public class DBVehicleController : ControllerBase
    {
        private readonly VehiclesDBContext _context;

        public DBVehicleController (VehiclesDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// To get all the Vehicles from DB
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetVehicles()
        {
            return Ok(_context.VehiclesDbSet.ToList());
        }

        /// <summary>
        /// To get the Vehicles based on the vehicleID parameter
        /// </summary>
        /// <param name="vehicleID"></param>
        /// <returns></returns>
        [HttpGet("{vehicleID}")]
        public IActionResult GetVehicleByID(int vehicleID)
        {
            return Ok(_context.VehiclesDbSet.Where(c => c.VehicleID == vehicleID).ToList());
        }

        /// <summary>
        /// Creating record using EF with DBContext
        /// </summary>
        /// <param name="dbVehicleItem"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateVehicleEntry(VehicleForDb dbVehicleItem)
        {
            _context.VehiclesDbSet.Add(
                new VehicleForDb()
                {
                    DriveTypeID = dbVehicleItem.DriveTypeID,
                    EngineDescriptionID = dbVehicleItem.EngineDescriptionID,
                    MakeID = dbVehicleItem.MakeID,
                    ModelID = dbVehicleItem.ModelID,
                    ConstructionYearID = dbVehicleItem.ConstructionYearID,
                    ModifyDate = dbVehicleItem.ModifyDate,
                    VehiclePrice = dbVehicleItem.VehiclePrice

                }) ;

            _context.SaveChanges();

            return Ok("Record created!");
        }
        


    }
}
