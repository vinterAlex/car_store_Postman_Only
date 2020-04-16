using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsStore
{
    public class Cars
    {
        public Cars(int carId)
        {
            CarID = carId;
        }
        
        public int CarID { get; set; }
        public int DriveTypeID { get; set; }
        public int EngineDescriptionID { get; set; }
        public int MakeID { get; set; }
        public int ModelID { get; set; }
        public int ConstructionYearID { get; set; }
        public DateTime CreateDate { get; set; }
        public int VehiclePrice { get; set; }

        

    }
}
