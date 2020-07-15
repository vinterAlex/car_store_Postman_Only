using Models;
using Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApplication.Methods
{
    public class VehicleMethods
    {
        public List<Vehicle>RetrieveVehicles()
        {

            try
            {

                SqlConnection conn = new SqlConnection(SqlConnectionPath.connectionString);
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandText = "select v.VehicleID,v.DriveTypeID,v.EngineDescriptionID,v.MakeID,v.ModelID,ct.Name[ConstructionYear],ModifyDate, " +
                    "VehiclePrice from Vehicles v " +
                    " inner join CarConstructionYear ct " +
                    " on ct.CarConstructionYearID = v.ConstructionYearID ;";

                conn.Open();

                DataTable dt = new DataTable();



                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);

                    List<Vehicle> carsList = new List<Vehicle>();


                    foreach (DataRow row in dt.Rows)
                    {
                        Vehicle car = new Vehicle();

                        //convert for all INT/Date's etc...
                        car.VehicleID = Convert.ToInt32(row["VehicleID"]);
                        car.DriveTypeID = Convert.ToInt32(row["DriveTypeID"]);
                        car.EngineDescriptionID = Convert.ToInt32(row["EngineDescriptionID"]);
                        car.MakeID = Convert.ToInt32(row["MakeID"]);
                        car.ModelID = Convert.ToInt32(row["ModelID"]);
                        car.ConstructionYear = Convert.ToString(row["ConstructionYear"]);
                        car.ModifyDate = Convert.ToDateTime(row["ModifyDate"]);
                        car.VehiclePrice = Convert.ToInt32(row["VehiclePrice"]);

                        carsList.Add(car);
                    }

                    return carsList;


                }
            }
            catch (SqlException SqlEx)
            {
                Exception newEx = new Exception("Something failed", SqlEx);
                throw newEx;
                
            }
        }

        public List<VehicleDetailed>RetrieveVehicleById(int vehicleIDParam)
        {
            try
            {

                SqlConnection conn = new SqlConnection(SqlConnectionPath.connectionString);
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                //cmd.CommandText = "select * from Vehicles where VehicleID = " + vehicleIDParam;
                cmd.CommandText = "select v.VehicleID,dt.Name[DriveType],eg.Name[EngineDescription],mk.Name[Make],mt.Name[Model],ct.Name[ConstructionYear],v.ModifyDate,v.VehiclePrice " +
                "from Vehicles v " +
                "	inner join DriveTypeDescription dt " +
                "		on dt.DriveTypeID = v.DriveTypeID " +
                "	inner join EngineDescriptionType eg " +
                "		on eg.EngineDescriptionTypeID = v.EngineDescriptionID " +
                "	inner join MakeType mk " +
                "		on mk.MakeTypeID = v.MakeID " +
                "	inner join ModelType mt " +
                "		on mt.ModelTypeID = v.ModelID " +
                "	inner join CarConstructionYear ct " +
                "		on ct.CarConstructionYearID = v.ConstructionYearID " +
                " where v.VehicleID = @VehicleID";

                SqlParameter param = new SqlParameter();

                param.ParameterName = "@VehicleID";
                param.Value = vehicleIDParam;

                cmd.Parameters.Add(param);



                conn.Open();

                DataTable dt = new DataTable();



                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);

                    List<VehicleDetailed> carsList = new List<VehicleDetailed>();



                    foreach (DataRow row in dt.Rows)
                    {
                        VehicleDetailed cars = new VehicleDetailed();

                        cars.VehicleID = Convert.ToInt32(row["VehicleID"]);
                        cars.DriveType = Convert.ToString(row["DriveType"]);
                        cars.EngineDescription = Convert.ToString(row["EngineDescription"]);
                        cars.Make = Convert.ToString(row["Make"]);
                        cars.Model = Convert.ToString(row["Model"]);
                        cars.ConstructionYear = Convert.ToInt32(row["ConstructionYear"]);
                        cars.ModifyDate = Convert.ToDateTime(row["ModifyDate"]);
                        cars.VehiclePrice = Convert.ToString(row["VehiclePrice"]);


                        carsList.Add(cars);
                    }

                    return carsList;

                }
            }
            catch (SqlException sqlEx)
            {
                Exception newEx = new Exception("Something failed", sqlEx);
                throw newEx;
            }
        }

        public List<VehicleDetailed> GetVehicleByYear(int year)
        {
            try
            {

                SqlConnection conn = new SqlConnection(SqlConnectionPath.connectionString);
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;

                cmd.CommandText = "select v.VehicleID,dt.Name[DriveType],eg.Name[EngineDescription],mk.Name[Make],mt.Name[Model],ct.Name[ConstructionYear],v.ModifyDate,v.VehiclePrice  " +
                "from Vehicles v " +
                "	inner join DriveTypeDescription dt " +
                "		on dt.DriveTypeID = v.DriveTypeID " +
                "	inner join EngineDescriptionType eg " +
                "		on eg.EngineDescriptionTypeID = v.EngineDescriptionID " +
                "	inner join MakeType mk " +
                "		on mk.MakeTypeID = v.MakeID " +
                "	inner join ModelType mt " +
                "		on mt.ModelTypeID = v.ModelID " +
                "	inner join CarConstructionYear ct " +
                "		on ct.CarConstructionYearID = v.ConstructionYearID " +
                " where ct.Name = @constructionYear";

                SqlParameter param = new SqlParameter();

                param.ParameterName = "@constructionYear";
                param.Value = year;

                cmd.Parameters.Add(param);



                conn.Open();

                DataTable dt = new DataTable();



                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);

                    List<VehicleDetailed> carsList = new List<VehicleDetailed>();



                    foreach (DataRow row in dt.Rows)
                    {
                        VehicleDetailed cars = new VehicleDetailed();

                        cars.VehicleID = Convert.ToInt32(row["VehicleID"]);
                        cars.DriveType = Convert.ToString(row["DriveType"]);
                        cars.EngineDescription = Convert.ToString(row["EngineDescription"]);
                        cars.Make = Convert.ToString(row["Make"]);
                        cars.Model = Convert.ToString(row["Model"]);
                        cars.ConstructionYear = Convert.ToInt32(row["ConstructionYear"]);
                        cars.ModifyDate = Convert.ToDateTime(row["ModifyDate"]);
                        cars.VehiclePrice = Convert.ToString(row["VehiclePrice"]);


                        carsList.Add(cars);
                    }

                    return carsList;

                }
            }
            catch (SqlException sqlEx)
            {
                Exception newEx = new Exception("Something failed", sqlEx);
                throw newEx;
            }
        }

        public List<VehicleDetailed> GetVehicleByMake(string make)
        {
            try
            {

                SqlConnection conn = new SqlConnection(SqlConnectionPath.connectionString);
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;

                cmd.CommandText = "select v.VehicleID,dt.Name[DriveType],eg.Name[EngineDescription],mk.Name[Make],mt.Name[Model],ct.Name[ConstructionYear],v.ModifyDate,v.VehiclePrice  " +
                "from Vehicles v " +
                "	inner join DriveTypeDescription dt " +
                "		on dt.DriveTypeID = v.DriveTypeID " +
                "	inner join EngineDescriptionType eg " +
                "		on eg.EngineDescriptionTypeID = v.EngineDescriptionID " +
                "	inner join MakeType mk " +
                "		on mk.MakeTypeID = v.MakeID " +
                "	inner join ModelType mt " +
                "		on mt.ModelTypeID = v.ModelID " +
                "	inner join CarConstructionYear ct " +
                "		on ct.CarConstructionYearID = v.ConstructionYearID " +
                " where mk.Name = @vehicleMake";

                SqlParameter param = new SqlParameter();

                param.ParameterName = "@vehicleMake";
                param.Value = make;

                cmd.Parameters.Add(param);



                conn.Open();

                DataTable dt = new DataTable();



                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);

                    List<VehicleDetailed> carsList = new List<VehicleDetailed>();



                    foreach (DataRow row in dt.Rows)
                    {
                        VehicleDetailed cars = new VehicleDetailed();

                        cars.VehicleID = Convert.ToInt32(row["VehicleID"]);
                        cars.DriveType = Convert.ToString(row["DriveType"]);
                        cars.EngineDescription = Convert.ToString(row["EngineDescription"]);
                        cars.Make = Convert.ToString(row["Make"]);
                        cars.Model = Convert.ToString(row["Model"]);
                        cars.ConstructionYear = Convert.ToInt32(row["ConstructionYear"]);
                        cars.ModifyDate = Convert.ToDateTime(row["ModifyDate"]);
                        cars.VehiclePrice = Convert.ToString(row["VehiclePrice"]);


                        carsList.Add(cars);
                    }

                    return carsList;

                }
            }
            catch (SqlException sqlEx)
            {
                Exception newEx = new Exception("Something failed", sqlEx);
                throw newEx;
            }
        }


        public string AddNewVehicle(CreateVehicle vItem)
        {
            
            try
            {

                SqlConnection conn = new SqlConnection(SqlConnectionPath.connectionString);
                SqlCommand cmd = new SqlCommand();



                cmd.Connection = conn; //to open the connection
                //cmd.CommandText = "select * from Vehicles where VehicleID = " + vehicleIDParam;
                cmd.CommandText = "INSERT INTO Vehicles (DriveTypeID,EngineDescriptionID,MakeID,ModelID,ConstructionYearID,ModifyDate,VehiclePrice)" +
                    "Values(@DriveTypeID,@EngineDescription,@MakeID,@ModelID,@ConstructionYearID,@ModifyDate,@VehiclePrice)";


                cmd.Parameters.AddWithValue("@DriveTypeID", SqlDbType.Int).Value = vItem.DriveTypeID;
                cmd.Parameters.AddWithValue("@EngineDescription", vItem.EngineDescriptionID);
                cmd.Parameters.AddWithValue("@MakeID", vItem.MakeID);
                cmd.Parameters.AddWithValue("@ModelID", vItem.ModelID);
                cmd.Parameters.AddWithValue("@ConstructionYearID", vItem.ConstructionYearID);
                cmd.Parameters.AddWithValue("@ModifyDate", vItem.ModifyDate = DateTime.Now);
                cmd.Parameters.AddWithValue("@VehiclePrice", vItem.VehiclePrice);



                conn.Open();

                DataTable dt = new DataTable();

                cmd.ExecuteReader();

                return "Vehicle Added from 'VehicleMethod class'";

            }
            catch (SqlException sqlEx)
            {
                Exception newEx = new Exception("Something failed", sqlEx);
                throw newEx;
            }
        }

        public string UpdateVehicle(int vehicleID, CreateVehicle updateVehicleItem)
        {
            try
            {
                SqlConnection conn = new SqlConnection(SqlConnectionPath.connectionString);
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                //cmd.CommandText = "select * from Vehicles where VehicleID = " + vehicleIDParam;
                cmd.CommandText = " update Vehicles " +
                                  " set DriveTypeID = @DriveTypeID,EngineDescriptionID = @EngineDescription,MakeID = @MakeID,ModelID = @ModelID,ConstructionYearID = @ConstructionYearID , " +
                                  " ModifyDate = GETUTCDATE(),VehiclePrice = @VehiclePrice " +
                                  " where VehicleID = @vehicleID";

                cmd.Parameters.AddWithValue("@vehicleID", vehicleID); // vehicleID for URI

                cmd.Parameters.AddWithValue("@DriveTypeID", updateVehicleItem.DriveTypeID);
                cmd.Parameters.AddWithValue("@EngineDescription", updateVehicleItem.EngineDescriptionID);
                cmd.Parameters.AddWithValue("@MakeID", updateVehicleItem.MakeID);
                cmd.Parameters.AddWithValue("@ModelID", updateVehicleItem.ModelID);
                cmd.Parameters.AddWithValue("@ConstructionYearID", updateVehicleItem.ConstructionYearID);
                cmd.Parameters.AddWithValue("@ModifyDate", updateVehicleItem.ModifyDate = DateTime.Now);
                cmd.Parameters.AddWithValue("@VehiclePrice", updateVehicleItem.VehiclePrice);


                conn.Open();

                DataTable dt = new DataTable();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);

                    //need to show what ID was updated or created based on rowindex, i think...

                    return ("Vehicle [" + vehicleID + "] Updated successfully! from Method class");

                }
            }
            catch (SqlException sqlEx)
            {
                Exception newEx = new Exception("Something failed", sqlEx);
                throw newEx;
            }
        }

        public string DeleteVehicle(int vehicleID)
        {
            try
            {
                SqlConnection conn = new SqlConnection(SqlConnectionPath.connectionString);
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;

                cmd.CommandText = " delete from Vehicles " +
                                  " where VehicleID = @vehicleID";

                cmd.Parameters.AddWithValue("@vehicleID", vehicleID); // vehicleID for URI

                conn.Open();

                DataTable dt = new DataTable();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);



                    return "Vehicle [" + vehicleID.ToString() + "] Deleted successfully! from Method class";

                }
            }
            catch (SqlException sqlEx)
            {
                Exception newEx = new Exception("Something failed", sqlEx);
                throw newEx;
            }
        }


    }
}
