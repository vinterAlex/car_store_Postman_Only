﻿
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using VehicleUtils;

namespace CarStoreApplication.Controllers
{
    [ApiController]
    [Route("api/shop/vehicle/[controller]")]
    public class AddVehicleController : ControllerBase
    {



        [HttpPost]
        public IActionResult AddVehicle([FromBody] VehicleForCreation vItem)
        {
            try
            {

                SqlConnection conn = new SqlConnection(Utils.connectionString);
                SqlCommand cmd = new SqlCommand();

                

                cmd.Connection = conn; //to open the connection
                //cmd.CommandText = "select * from Vehicles where VehicleID = " + vehicleIDParam;
                cmd.CommandText = "INSERT INTO Vehicles (DriveTypeID,EngineDescriptionID,MakeID,ModelID,ConstructionYearID,ModifyDate,VehiclePrice)" +
                    "Values(@DriveTypeID,@EngineDescription,@MakeID,@ModelID,@ConstructionYearID,@ModifyDate,@VehiclePrice)";


                cmd.Parameters.AddWithValue("@DriveTypeID", SqlDbType.Int).Value = vItem.DriveTypeID;
                cmd.Parameters.AddWithValue("@EngineDescription", vItem.EngineDescriptionID);
                cmd.Parameters.AddWithValue("@MakeID", vItem.MakeID);
                cmd.Parameters.AddWithValue("@ModelID", vItem.ModelID);
                cmd.Parameters.AddWithValue("@ConstructionYearID", vItem.ConstructionYearID);
                cmd.Parameters.AddWithValue("@ModifyDate", vItem.ModifyDate=DateTime.Now);
                cmd.Parameters.AddWithValue("@VehiclePrice", vItem.VehiclePrice);



                conn.Open();

                DataTable dt = new DataTable();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);


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
