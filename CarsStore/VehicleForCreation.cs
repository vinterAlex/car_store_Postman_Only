using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsStore
{
    public class VehicleForCreation
    {
        public int VehicleID { get; set; }
        
        public int DriveTypeID { get; set; }
        public int EngineDescriptionID { get; set; }
        public int MakeID { get; set; }
        public int ModelID { get; set; }
        public int ConstructionYearID { get; set; }
        public DateTime ModifyDate { get; set; }
        public int VehiclePrice { get; set; }

    }
}
