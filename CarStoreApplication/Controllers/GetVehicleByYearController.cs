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
    [Route("api/shop/[controller]")]
    public class GetVehicleByYearController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetByYear(int constYear)
        {
            try
            {

                SqlConnection conn = new SqlConnection(Utils.connectionString);
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
                " where ct.Name = @constructionYear";

                SqlParameter param = new SqlParameter();

                param.ParameterName = "@constructionYear";
                param.Value = constYear;

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
