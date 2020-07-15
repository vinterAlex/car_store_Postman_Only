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
        public string DriveType { get; set; }
        public string EngineDescription { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int ConstructionYear { get; set; }
        public DateTime ModifyDate { get; set; }
        public string VehiclePrice { get; set; }
    }
}
