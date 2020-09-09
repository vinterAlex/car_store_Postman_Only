using CarStoreApplication.Models;

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
    [Route("api/[controller]")]
    public class IncomesExpensesController : ControllerBase
    {
        IncomesExpensesMethods mic = new IncomesExpensesMethods();


        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var total = mic.();
        //    return Ok(total);
        //}
        [HttpGet("totalIncome")]
        public IActionResult GetTotalIncome()
        {
            var totalIncome = mic.GetTotalIncome();
            return Ok(totalIncome);
        }

        [HttpGet("incomes")]
        public IActionResult GetIncomes()
        {
            var income = mic.GetIncomes();
            
            return Ok(income);
        }


        [HttpGet("expenses")]
        public IActionResult GetExpenses()
        {
            var expense = mic.GetExpenses();

            return Ok(expense);
        }
    }
}
