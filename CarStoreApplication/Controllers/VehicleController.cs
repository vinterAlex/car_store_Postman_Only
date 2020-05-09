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
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {



        /// <summary>
        /// Get the list of all vehicles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult RetrieveVehicle()
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

                    List<Vehicles> carsList = new List<Vehicles>();


                    foreach (DataRow row in dt.Rows)
                    {
                        Vehicles car = new Vehicles();

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



        /// <summary>
        /// Find vehicles based on the ID
        /// </summary>
        /// <param name="vehicleIDParam"></param>
        /// <returns></returns>
        // in API too look after the vehicle ID with detailed informations
        [HttpGet("{vehicleIDParam}")]
        public IActionResult RetrieveVehicle(int vehicleIDParam)
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

                    List<VehiclesDetailed> carsList = new List<VehiclesDetailed>();



                    foreach (DataRow row in dt.Rows)
                    {
                        VehiclesDetailed cars = new VehiclesDetailed();
                        

                        //convert for all INT/Date's etc...
                        cars.VehicleID = Convert.ToInt32(row["VehicleID"]);
                        cars.DriveTypeID = Convert.ToString(row["DriveTypeID"]);
                        cars.EngineDescriptionID = Convert.ToString(row["EngineDescription"]);
                        cars.MakeID = Convert.ToString(row["Make"]);
                        cars.ModelID = Convert.ToString(row["Model"]);
                        cars.ConstructionYearID = Convert.ToInt32(row["ConstructionYear"]);
                        cars.ModifyDate = Convert.ToDateTime(row["ModifyDate"]);
                        cars.VehiclePrice = Convert.ToInt32(row["VehiclePrice"]);
                        
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

        }

    }
}
