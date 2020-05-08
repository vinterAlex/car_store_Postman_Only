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
        public IActionResult RetrieveCars()
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
            catch (SqlException sqlEx)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, sqlEx);
            }

        }



        // in API too look after the vehicle ID with detailed informations
        [HttpGet("{vehicleIDParam}")]
        public IActionResult RetrieveCar(int vehicleIDParam)
        {

            try
            {

                SqlConnection conn = new SqlConnection(Utils.connectionString);
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                //cmd.CommandText = "select * from Vehicles where VehicleID = " + vehicleIDParam;
                cmd.CommandText= "select v.VehicleID,dt.Name[DriveTypeID],eg.Name[EngineDescription],mk.Name[Make],mt.Name[Model],ct.Name[ConstructionYear],v.ModifyDate,v.VehiclePrice " +
                "from Vehicles v " +
                "	inner join DriveTypeDescription dt " +
                "		on dt.DriveTypeID = v.DriveTypeID " +
                "	inner join EngineDescriptionType eg " +
                "		on eg.EngineDescriptionTypeID = v.EngineDescription " +
                "	inner join MakeType mk " +
                "		on mk.MakeTypeID = v.Make " +
                "	inner join ModelType mt " +
                "		on mt.ModelTypeID = v.Model " +
                "	inner join CarConstructionYear ct " +
                "		on ct.CarConstructionYearID = v.ConstructionYear " +
                "where v.VehicleID ="+vehicleIDParam;



                conn.Open();

                DataTable dt = new DataTable();



                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);

                    List<CarsDetailed> carsList = new List<CarsDetailed>();



                    foreach (DataRow row in dt.Rows)
                    {
                        CarsDetailed cars = new CarsDetailed();

                        //convert for all INT/Date's etc...
                        cars.VehicleID2 = Convert.ToInt32(row["VehicleID"]);
                        cars.DriveTypeID2 = Convert.ToString(row["DriveTypeID"]);
                        cars.EngineDescriptionID2 = Convert.ToString(row["EngineDescription"]);
                        cars.MakeID2 = Convert.ToString(row["Make"]);
                        cars.ModelID2 = Convert.ToString(row["Model"]);
                        cars.ConstructionYearID2 = Convert.ToInt32(row["ConstructionYear"]);
                        cars.ModifyDate2 = Convert.ToDateTime(row["ModifyDate"]);
                        cars.VehiclePrice2 = Convert.ToInt32(row["VehiclePrice"]);
                        

                        cmd.Parameters.AddWithValue("@VehicleID", vehicleIDParam);


                        carsList.Add(cars);
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
