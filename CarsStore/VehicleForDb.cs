using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsStore
{
    [Table("Vehicles")]
    public class VehicleForDb
    {

        

        [Key]
        public int VehicleID { get; set; }
        public int DriveTypeID { get; set; }
        public int EngineDescriptionID { get; set; }
        public int MakeID { get; set; }
        public int ModelID { get; set; }
        public int ConstructionYearID { get; set; }
        public DateTime ModifyDate { get; set; }
        public string VehiclePrice { get; set; }

    }
}
