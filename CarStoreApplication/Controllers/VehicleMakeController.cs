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
                cmd.CommandText = "select MakeTypeID, Name[Description] from MakeType;";
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
                        makeType.Description= Convert.ToString(row["Description"]);


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
                cmd.CommandText = "select MakeTypeID, Name[Description] from MakeType where MakeTypeID = @makeID;";

                SqlParameter param = new SqlParameter();

                param.ParameterName = "@makeID";
                param.Value = makeID;

                cmd.Parameters.Add(param);

                    

                conn.Open();

                DataTable dt = new DataTable();



                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);

                    List<MakeType> carsList = new List<MakeType>();



                    foreach (DataRow row in dt.Rows)
                    {
                        MakeType cars = new MakeType();

                        cars.MakeTypeID = Convert.ToInt32(row["MakeTypeID"]);
                        cars.Description = Convert.ToString(row["Description"]);

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
