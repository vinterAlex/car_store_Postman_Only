using VehicleUtils;
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
    public class DeleteVehicleController : ControllerBase
    {
        /// <summary>
        /// http://localhost:51680/api/shop/vehicle/deletevehicle?vehicleID=673
        /// </summary>
        /// <param name="vehicleID"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteVehicle(int vehicleID)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Utils.connectionString);
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                
                cmd.CommandText = " delete from Vehicles " +
                                  " where VehicleID = @vehicleID";

                cmd.Parameters.AddWithValue("@vehicleID", vehicleID); // vehicleID for URI

                conn.Open();

                DataTable dt = new DataTable();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);

                    VehicleForCreation add_vehicle = new VehicleForCreation();

                    return Ok("Vehicle ["+vehicleID.ToString() +"] Deleted successfully!");

                }
            }
            catch (SqlException sqlEx)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, sqlEx);
            }
        }
    }
}
