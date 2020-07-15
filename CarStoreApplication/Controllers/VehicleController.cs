
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
    public class VehicleController : ControllerBase
    {

        /// <summary>
        /// Get the list of all vehicles
        /// http://localhost:51680/api/shop/vehicle/
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult RetrieveVehicle()
        {
            try
            {

                SqlConnection conn = new SqlConnection(SqlConnectionPath.connectionString);
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandText = "select v.VehicleID,v.DriveTypeID,v.EngineDescriptionID,v.MakeID,v.ModelID,ct.Name[ConstructionYear],ModifyDate, " +
                    "VehiclePrice from Vehicles v " +
                    " inner join CarConstructionYear ct " +
                    " on ct.CarConstructionYearID = v.ConstructionYearID ;";

                conn.Open();

                DataTable dt = new DataTable();



                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);

                    List<Vehicle> carsList = new List<Vehicle>();


                    foreach (DataRow row in dt.Rows)
                    {
                        Vehicle car = new Vehicle();

                        //convert for all INT/Date's etc...
                        car.VehicleID = Convert.ToInt32(row["VehicleID"]);
                        car.DriveTypeID = Convert.ToInt32(row["DriveTypeID"]);
                        car.EngineDescriptionID = Convert.ToInt32(row["EngineDescriptionID"]);
                        car.MakeID = Convert.ToInt32(row["MakeID"]);
                        car.ModelID = Convert.ToInt32(row["ModelID"]);
                        car.ConstructionYear = Convert.ToString(row["ConstructionYear"]);
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
        /// 
        /// http://localhost:51680/api/shop/vehicle/674
        /// 
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
                cmd.CommandText = "select v.VehicleID,dt.Name[DriveType],eg.Name[EngineDescription],mk.Name[Make],mt.Name[Model],ct.Name[ConstructionYear],v.ModifyDate,v.VehiclePrice " +
                "from Vehicles v " +
                "	inner join DriveTypeDescription dt " +
                "		on dt.DriveTypeID = v.DriveTypeID " +
                "	inner join EngineDescriptionType eg " +
                "		on eg.EngineDescriptionTypeID = v.EngineDescriptionID " +
                "	inner join MakeType mk " +
                "		on mk.MakeTypeID = v.MakeID " +
                "	inner join ModelType mt " +
                "		on mt.ModelTypeID = v.ModelID " +
                "	inner join CarConstructionYear ct " +
                "		on ct.CarConstructionYearID = v.ConstructionYearID " +
                " where v.VehicleID = @VehicleID";

                SqlParameter param = new SqlParameter();

                param.ParameterName = "@VehicleID";
                param.Value = vehicleIDParam;

                cmd.Parameters.Add(param);



                conn.Open();

                DataTable dt = new DataTable();



                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);

                    List<VehiclesDetailed> carsList = new List<VehiclesDetailed>();



                    foreach (DataRow row in dt.Rows)
                    {
                        VehiclesDetailed cars = new VehiclesDetailed();

                        cars.VehicleID = Convert.ToInt32(row["VehicleID"]);
                        cars.DriveType = Convert.ToString(row["DriveType"]);
                        cars.EngineDescription = Convert.ToString(row["EngineDescription"]);
                        cars.Make = Convert.ToString(row["Make"]);
                        cars.Model = Convert.ToString(row["Model"]);
                        cars.ConstructionYear = Convert.ToInt32(row["ConstructionYear"]);
                        cars.ModifyDate = Convert.ToDateTime(row["ModifyDate"]);
                        cars.VehiclePrice = Convert.ToString(row["VehiclePrice"]);


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
