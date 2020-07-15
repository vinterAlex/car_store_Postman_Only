using Models;
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
    [Route("api/shop/vehicle/[controller]")]
    public class UpdateVehicleController : ControllerBase
    {
        /// <summary>
        /// http://localhost:51680/api/shop/vehicle/updatevehicle?vehicleid=674
        ///        {"DriveTypeID": 2,
        ///        "EngineDescriptionID": 2,
        ///        "MakeID":1,
        ///        "ModelID":1,
        ///        "ConstructionYearID":1,
        ///        "VehiclePrice":15532
        ///         }
        /// 
        /// </summary>
        /// <param name="vehicleID"></param>
        /// <param name="updateVehicleItem"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateVehicle(int vehicleID,[FromBody]CreateVehicle updateVehicleItem)
        {
            try
            {
                SqlConnection conn = new SqlConnection(SqlConnectionPath.connectionString);
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                //cmd.CommandText = "select * from Vehicles where VehicleID = " + vehicleIDParam;
                cmd.CommandText = " update Vehicles " +
                                  " set DriveTypeID = @DriveTypeID,EngineDescriptionID = @EngineDescription,MakeID = @MakeID,ModelID = @ModelID,ConstructionYearID = @ConstructionYearID , " +
                                  " ModifyDate = GETUTCDATE(),VehiclePrice = @VehiclePrice " +
                                  " where VehicleID = @vehicleID";

                cmd.Parameters.AddWithValue("@vehicleID",  vehicleID); // vehicleID for URI

                cmd.Parameters.AddWithValue("@DriveTypeID", updateVehicleItem.DriveTypeID);
                cmd.Parameters.AddWithValue("@EngineDescription", updateVehicleItem.EngineDescriptionID);
                cmd.Parameters.AddWithValue("@MakeID", updateVehicleItem.MakeID);
                cmd.Parameters.AddWithValue("@ModelID", updateVehicleItem.ModelID);
                cmd.Parameters.AddWithValue("@ConstructionYearID", updateVehicleItem.ConstructionYearID);
                cmd.Parameters.AddWithValue("@ModifyDate", updateVehicleItem.ModifyDate = DateTime.Now);
                cmd.Parameters.AddWithValue("@VehiclePrice", updateVehicleItem.VehiclePrice);


                conn.Open();

                DataTable dt = new DataTable();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);

                    //need to show what ID was updated or created based on rowindex, i think...

                    return Ok("Vehicle ["+vehicleID+"] Updated successfully!");

                }
            }
            catch (SqlException sqlEx)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, sqlEx);
            }
        }
    }
}
