using CarsStore;
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
    [Route("api/shop/[controller]")]
    public class AddVehicleController : ControllerBase
    {



        [HttpPost]
        //   public IActionResult AddVehicle([FromBody] int DriveTypeID, int EngineDescription, int Make, int Model, int ConstructionYear, int VehiclePrice)
        public IActionResult AddVehicle([FromBody] VehicleForCreation vItem)
        {
            try
            {

                SqlConnection conn = new SqlConnection(Utils.connectionString);
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn; //to open the connection
                //cmd.CommandText = "select * from Vehicles where VehicleID = " + vehicleIDParam;
                cmd.CommandText = "INSERT INTO Vehicles (DriveTypeID,EngineDescription,Make,Model,ConstructionYear,ModifyDate,VehiclePrice)" +
                                          "VALUES(" + vItem.DriveTypeID + ", " + vItem.EngineDescription + ", " + vItem.Make + ", " + vItem.Model + ", " + vItem.ConstructionYear + "," + " GETUTCDATE()," + vItem.VehiclePrice + ")";


                conn.Open();

                DataTable dt = new DataTable();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);

                    VehicleForCreation add_vehicle = new VehicleForCreation();

                    cmd.Parameters.AddWithValue("@DriveTypeID", vItem.DriveTypeID);
                    cmd.Parameters.AddWithValue("@EngineDescription", vItem.EngineDescription);
                    cmd.Parameters.AddWithValue("@Make", vItem.Make);
                    cmd.Parameters.AddWithValue("@Model", vItem.Model);
                    cmd.Parameters.AddWithValue("@ConstructionYear", vItem.ConstructionYear);
                    cmd.Parameters.AddWithValue("@VehiclePrice", vItem.VehiclePrice);

                    return Ok("Vehicle Added successfully!");

                }
            }
            catch (SqlException sqlEx)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, sqlEx);
            }

        }




    }
}
