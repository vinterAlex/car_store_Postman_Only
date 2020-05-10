using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleUtils
{
    public class VehiclesDetailed
    {
        // for the detailed view
        public int VehicleID { get; set; }
        public string DriveTypeID { get; set; }
        public string EngineDescriptionID { get; set; }
        public string MakeID { get; set; }
        public string ModelID { get; set; }
        public int ConstructionYearID { get; set; }
        public DateTime ModifyDate { get; set; }
        public string VehiclePrice { get; set; }
    }
}
