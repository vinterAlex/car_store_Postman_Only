using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarStoreApplication.Models
{
    public class Incomes
    {
        public int id { get; set; }
        public string description { get; set; }
        public int value { get; set; }

        public int total { get;  set; }

        
    }

    public class Expenses
    {
        public int id { get; set; }
        public string description { get; set; }
        public int value { get; set; }

        
    }


}
