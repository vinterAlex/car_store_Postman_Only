using Models;
using Utils;
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
    public class MakeController : ControllerBase
    {
        /// <summary>
        /// http://localhost:51680/api/shop/make/
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetVehicleMake()
        {
            try
            {

                SqlConnection conn = new SqlConnection(SqlConnectionPath.connectionString);
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandText = "select MakeTypeID, Name[Description] from MakeType;";
                conn.Open();

                DataTable dt = new DataTable();



                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);

                    List<Make> makeList = new List<Make>();


                    foreach (DataRow row in dt.Rows)
                    {
                        Make makeType = new Make();

                        //convert for all INT/Date's etc...
                        makeType.MakeID= Convert.ToInt32(row["MakeTypeID"]);
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
        /// 
        /// http://localhost:51680/api/shop/make/4
        /// 
        /// <param name="makeID"></param>
        /// <returns></returns>
        [HttpGet("{makeID}")]
        public IActionResult GetVehicleByMakeID(int makeID)
        {
            try
            {

                SqlConnection conn = new SqlConnection(SqlConnectionPath.connectionString);
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

                    List<Make> carsList = new List<Make>();



                    foreach (DataRow row in dt.Rows)
                    {
                        Make cars = new Make();

                        cars.MakeID = Convert.ToInt32(row["MakeTypeID"]);
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
