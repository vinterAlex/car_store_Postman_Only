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
    [Route("api/getcars")]
    public class CarController : ControllerBase
    {

        


        [HttpGet]
        public IActionResult RetrieveCars(int vehicleIDParam)
        {
            try
            {

                SqlConnection conn = new SqlConnection(Utils.connectionString);
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandText = "select * from Vehicles;";
                conn.Open();

                DataTable dt = new DataTable();



                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);

                    List<Cars> carsList = new List<Cars>();


                    foreach (DataRow row in dt.Rows)
                    {
                        Cars car = new Cars();

                        //convert for all INT/Date's etc...
                        car.VehicleID = Convert.ToInt32(row["VehicleID"]);
                        car.DriveTypeID = Convert.ToInt32(row["DriveTypeID"]);
                        car.EngineDescriptionID = Convert.ToInt32(row["EngineDescription"]);
                        car.MakeID = Convert.ToInt32(row["Make"]);
                        car.ModelID = Convert.ToInt32(row["Model"]);
                        car.ConstructionYearID = Convert.ToInt32(row["ConstructionYear"]);
                        car.ModifyDate = Convert.ToDateTime(row["ModifyDate"]);
                        car.VehiclePrice = Convert.ToInt32(row["VehiclePrice"]);

                        

                        carsList.Add(car);
                    }

                    return Ok(carsList);

                }
            }
            catch(SqlException sqlEx)
            {
               return StatusCode((int)HttpStatusCode.InternalServerError, sqlEx);
            }



            //return Ok("RetrieveCar method [OK]");
        }


        [HttpGet("{vehicleIDParam}")]
        public IActionResult RetrieveCar(int vehicleIDParam)
        {
             
            try
            {

                SqlConnection conn = new SqlConnection(Utils.connectionString);
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandText = "select * from Vehicles where VehicleID = " + vehicleIDParam;
                conn.Open();

                DataTable dt = new DataTable();



                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);

                    List<Cars> carsList = new List<Cars>();

                    

                    foreach (DataRow row in dt.Rows)
                    {
                        Cars car = new Cars();

                        //convert for all INT/Date's etc...
                        car.VehicleID = Convert.ToInt32(row["VehicleID"]);
                        car.DriveTypeID = Convert.ToInt32(row["DriveTypeID"]);
                        car.EngineDescriptionID = Convert.ToInt32(row["EngineDescription"]);
                        car.MakeID = Convert.ToInt32(row["Make"]);
                        car.ModelID = Convert.ToInt32(row["Model"]);
                        car.ConstructionYearID = Convert.ToInt32(row["ConstructionYear"]);
                        car.ModifyDate = Convert.ToDateTime(row["ModifyDate"]);
                        car.VehiclePrice = Convert.ToInt32(row["VehiclePrice"]);


                        cmd.Parameters.AddWithValue("@VehicleID", vehicleIDParam);
                        //cmd.Parameters["@VehicleID"].Value=vehicleIDParam;

                        carsList.Add(car);
                    }

                    return Ok(carsList);

                }
            }
            catch (SqlException sqlEx)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, sqlEx);
            }
            



            //return Ok("RetrieveCar method [OK]");
        }




    }
}
