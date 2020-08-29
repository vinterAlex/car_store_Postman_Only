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
using CarStoreApplication.Methods;

namespace CarStoreApplication.Controllers
{
    [ApiController]
    [Route("api/shop/[controller]")]
    public class MakeController : ControllerBase
    {
        MakeMethods make = new MakeMethods();
        /// <summary>
        /// http://localhost:51680/api/shop/make/
        /// /// http://localhost:51680/api/shop/make/makeid
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetVehicleMake()
        {
            var makeResult = make.GetMakeType();
            return Ok(makeResult);
        }



        [HttpGet("{makeID}")]
        public IActionResult GetVehicleByMakeID(int makeID)
        {
            var makeResult = make.GetMakeById(makeID);
            return Ok(makeResult);
        }

        [HttpPost("addnewmake")]
        public IActionResult AddNewMake([FromBody] Make makeItem)
        {
            var CreateResult = make.AddNewMake(makeItem);
            return Ok(CreateResult);
        }

        // https://localhost:44310/api/shop/make/updatemake?makeID=53
        [HttpPut("updatemake")]
        public IActionResult UpdateMake(int makeID,[FromBody]Make makeItem)
        {
            var makeUpdate = make.UpdateMake(makeID,makeItem);
            return Ok(makeUpdate);
        }

        //https://localhost:44310/api/shop/make/deletemake?makeID=55
        [HttpDelete("deletemake")]
        public IActionResult DeleteMake(int makeID)
        {
            var deleteResult = make.DeleteMake(makeID);
            return Ok(deleteResult);
        }



    }
}
