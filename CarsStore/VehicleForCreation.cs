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
        //[MaxLength(3)] //-- work only for strings
        
        public int DriveTypeID { get; set; }
        public int EngineDescription { get; set; }
        public int Make { get; set; }
        public int Model { get; set; }
        public int ConstructionYear { get; set; }
        public DateTime ModifyDate { get; set; }
        public int VehiclePrice { get; set; }

    }
}
