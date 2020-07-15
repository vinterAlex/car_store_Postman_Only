using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    
    public class Vehicle
    {

        [Key]
        public int VehicleID { get; set; }
        public int DriveTypeID { get; set; }
        public int EngineDescriptionID { get; set; }
        public int MakeID { get; set; }
        public int ModelID { get; set; }
        public string ConstructionYear { get; set; }
        public DateTime ModifyDate { get; set; }
        public int VehiclePrice { get; set; }


    }

    public class VehicleDetailed
    {
        public int VehicleID { get; set; }
        public string DriveType { get; set; }
        public string EngineDescription { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int ConstructionYear { get; set; }
        public DateTime ModifyDate { get; set; }
        public string VehiclePrice { get; set; }
    }

    public class CreateVehicle
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
