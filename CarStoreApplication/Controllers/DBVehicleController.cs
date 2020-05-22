using VehicleUtils;
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
        /// Creating record using EF with DBContext experiment
        /// </summary>
        /// <param name="dbVehicleItem"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateVehicle(VehicleForDb dbVehicleItem)
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

        /// <summary>
        /// change record
        /// </summary>
        /// <param name="vehicleItem"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateVehicle(VehicleForDb vehicleItem)
        {
            var existingEntry = _context.VehiclesDbSet.Where(v => v.VehicleID == vehicleItem.VehicleID).FirstOrDefault<VehicleForDb>();


            if(existingEntry != null)
            {
                existingEntry.DriveTypeID = vehicleItem.DriveTypeID;
                existingEntry.EngineDescriptionID = vehicleItem.EngineDescriptionID;
                existingEntry.MakeID = vehicleItem.MakeID;
                existingEntry.ModelID = vehicleItem.ModelID;
                existingEntry.ConstructionYearID = vehicleItem.ConstructionYearID;
                existingEntry.ModifyDate = vehicleItem.ModifyDate;
                existingEntry.VehiclePrice = vehicleItem.VehiclePrice;

                _context.SaveChanges();
            }
            else
            {
                return NotFound("No entry found based on this criteria.");
            }

            return Ok("Entry "+existingEntry+" Updated");


        }

        /// <summary>
        /// To delete an entry with EF and DB Context
        /// </summary>
        /// <param name="idToRemove"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult RemoveVehicle(int idToRemove) // URL ?idToRemove={id}
        {
            var checkEntry = _context.VehiclesDbSet
                .Where(s => s.VehicleID == idToRemove)
                .FirstOrDefault();

            _context.Entry(checkEntry).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

            _context.SaveChanges();

            return Ok("Entry deleted successfully");
        }
        
        


    }
}
