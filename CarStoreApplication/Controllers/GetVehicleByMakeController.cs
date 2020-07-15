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
    public class GetVehicleByMakeController : ControllerBase
    {
        /// <summary>
        /// http://localhost:51680/api/shop/vehicle/getvehiclebymake?vehiclemake=Audi
        /// </summary>
        /// <param name="vehicleMake"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetByMake(string vehicleMake)
        {
            try
            {

                SqlConnection conn = new SqlConnection(SqlConnectionPath.connectionString);
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;

                cmd.CommandText = "select v.VehicleID,dt.Name[DriveType],eg.Name[EngineDescription],mk.Name[Make],mt.Name[Model],ct.Name[ConstructionYear],v.ModifyDate,v.VehiclePrice  " +
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
                " where mk.Name = @vehicleMake";

                SqlParameter param = new SqlParameter();

                param.ParameterName = "@vehicleMake";
                param.Value = vehicleMake;

                cmd.Parameters.Add(param);



                conn.Open();

                DataTable dt = new DataTable();



                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);

                    List<VehicleDetailed> carsList = new List<VehicleDetailed>();



                    foreach (DataRow row in dt.Rows)
                    {
                        VehicleDetailed cars = new VehicleDetailed();

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
