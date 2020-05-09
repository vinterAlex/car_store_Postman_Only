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
    public class VehicleMakeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetVehicleMake()
        {
            try
            {

                SqlConnection conn = new SqlConnection(Utils.connectionString);
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandText = "select MakeTypeID, Name from MakeType;";
                conn.Open();

                DataTable dt = new DataTable();



                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);

                    List<MakeType> makeList = new List<MakeType>();


                    foreach (DataRow row in dt.Rows)
                    {
                        MakeType makeType = new MakeType();

                        //convert for all INT/Date's etc...
                        makeType.MakeTypeID= Convert.ToInt32(row["MakeTypeID"]);
                        makeType.Name = Convert.ToString(row["Name"]);


                        makeList.Add(makeType);
                    }

                    return Ok(makeList);

                }
            }
            catch (SqlException sqlEx)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, sqlEx);
            }
        }



        /// <summary>
        /// To get the vehicle by the MakeID
        /// </summary>
        /// <param name="makeID"></param>
        /// <returns></returns>
        [HttpGet("{makeID}")]
        public IActionResult GetVehicleByMakeID(int makeID)
        {
            try
            {

                SqlConnection conn = new SqlConnection(Utils.connectionString);
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandText = "select v.VehicleID,dt.Name[DriveTypeID],eg.Name[EngineDescription],mk.Name[Make],mt.Name[Model],ct.Name[ConstructionYear],v.ModifyDate,v.VehiclePrice " +
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
                "where v.Make =" + makeID;


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

                        cmd.Parameters.AddWithValue("@makeID", makeID);

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
