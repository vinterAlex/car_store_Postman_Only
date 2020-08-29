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
    public class MakeMethods
    {
        public List<Make> GetMakeType()
        {
            try
            {
                SqlConnection conn = new SqlConnection(SqlConnectionPath.connectionString);
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandText = "select MakeTypeID, Name from MakeType;";
                conn.Open();

                DataTable dt = new DataTable();



                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);

                    List<Make> makeList = new List<Make>();


                    foreach (DataRow row in dt.Rows)
                    {
                        Make makeType = new Make();

                        //convert for all INT/Date's etc...
                        makeType.MakeID = Convert.ToInt32(row["MakeTypeID"]);
                        makeType.Name = Convert.ToString(row["Name"]);


                        makeList.Add(makeType);
                    }

                    return makeList;

                }
            }
            catch (SqlException SqlEx)
            {
                Exception newEx = new Exception("Something failed", SqlEx);
                throw newEx;

            }
        }

        public List<Make> GetMakeById(int makeID)
        {
            try
            {

                SqlConnection conn = new SqlConnection(SqlConnectionPath.connectionString);
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandText = "select MakeTypeID, Name from MakeType where MakeTypeID = @makeID;";

                SqlParameter param = new SqlParameter();

                param.ParameterName = "@makeID";
                param.Value = makeID;

                cmd.Parameters.Add(param);



                conn.Open();

                DataTable dt = new DataTable();



                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);

                    List<Make> makeList = new List<Make>();



                    foreach (DataRow row in dt.Rows)
                    {
                        Make cars = new Make();

                        cars.MakeID = Convert.ToInt32(row["MakeTypeID"]);
                        cars.Name = Convert.ToString(row["Name"]);

                        makeList.Add(cars);
                    }

                    return makeList;

                }
            }
            catch (SqlException SqlEx)
            {
                Exception newEx = new Exception("Something failed", SqlEx);
                throw newEx;

            }
        }

        public string AddNewMake(Make makeItem)
        {

            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(SqlConnectionPath.connectionString);
            SqlTransaction transaction = null;

            try
            {
                conn.Open();
                transaction = conn.BeginTransaction();


                cmd.Connection = conn; //to open the connection
                //cmd = new SqlCommand("insert into MakeType(Name,CreateDate) " +
                //                   "VALUES(@Name, GETUTCDATE())",conn,transaction);

                //cmd = new SqlCommand("IF NOT EXISTS (SELECT Name FROM MakeType "+
                //                                    "WHERE Name = @Name) " +
                //                        "BEGIN " +
                //                        "  INSERT INTO MakeType(Name, CreateDate) " +
                //                        "  VALUES(@Name, GETUTCDATE()) " +
                //                        "END",conn,transaction);
                cmd = new SqlCommand("INSERT INTO MakeType(Name,CreateDate) " +
                    "SELECT @Name,GETUTCDATE()" +
                    "  WHERE NOT EXISTS (SELECT Name from MakeType where Name = @Name)", conn, transaction);


                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name", makeItem.Name); 
                

                SqlDataReader reader = cmd.ExecuteReader();
                reader.Close();

                transaction.Commit();
                var rowsAffected = reader.RecordsAffected.ToString();

                if(reader.RecordsAffected == 0)
                {
                    
                    return "Make Item already exists in DB. Rows affected: " + rowsAffected;
                }
                else
                {
                    return "Make Item added successfully. Rows affected: " + rowsAffected;
                }

                
                //return "Make Item Added from 'MakeMethod class with transaction!'";
            }
            catch (SqlException SqlEx)
            {
                transaction.Rollback();
                return "Make Item cannot be added. Already exists in DB with the same NAME. Message: "+SqlEx.Message;

            }
        }

        public string UpdateMake(int makeID, Make makeItem)
        {

            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(SqlConnectionPath.connectionString);
            SqlTransaction transaction = null; 

            try
            {
                conn.Open();
                transaction = conn.BeginTransaction();

                cmd.Connection = conn;


                cmd = new SqlCommand("IF ( NOT EXISTS (SELECT Name from MakeType where MakeTypeID = @MakeID and Name = @Name)) "+
                                      "BEGIN " +
                                      "Update MakeType " +
                                      "Set Name = @Name " +
                                      "where MakeTypeID = @MakeID " +
                                      "END",conn,transaction);


                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@MakeID", makeID); // vehicleID for URI

                cmd.Parameters.AddWithValue("@Name", makeItem.Name);

                SqlDataReader reader = cmd.ExecuteReader();
                reader.Close();

                transaction.Commit();

                var rowsAffected = reader.RecordsAffected.ToString();

                if (reader.RecordsAffected == 0 || reader.RecordsAffected == -1)
                {

                    return "Make Item with ID: " + makeID + " already has this Name.";
                }
                else
                {
                    return "Make Item with ID:" + makeID + " updated succesfully! Rows Affected: " + rowsAffected;
                }

            }
            catch (SqlException sqlEx)
            {
                transaction.Rollback();
                return ("Make with ID: [" + makeID + "] cannot be updated. Transaction ROLLBACK. Message:"+sqlEx.Message);
            }
        }


        public string DeleteMake(int makeID)
        {

            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(SqlConnectionPath.connectionString);
            SqlTransaction transaction = null; ;

            try
            {

                conn.Open();

                transaction = conn.BeginTransaction();

                //cmd = new SqlCommand("delete from MakeType where MakeTypeID = @makeID", conn, transaction);

                cmd = new SqlCommand("IF EXISTS( "+
                                           "SELECT MakeTypeID "+
                                           "from MakeType "+
                                           "where MakeTypeID = @makeID) "+
                                       "delete MakeType "+
                                       "where MakeTypeID = @makeID",conn,transaction);



                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@makeID", makeID);

                SqlDataReader reader = cmd.ExecuteReader();
                reader.Close();

                transaction.Commit();

                var rowsAffected = reader.RecordsAffected.ToString();

                if (reader.RecordsAffected == 0 || reader.RecordsAffected == -1)
                {

                    return "Make Item with ID: " + makeID + " does not exist in DB.";
                }
                else
                {
                    return "Make Item with ID:" + makeID + " deleted from DB. Rows Affected: " + rowsAffected;
                }

                
            }
            catch (SqlException sqlEx)
            {
                transaction.Rollback();
                return "For MakeID: [" + makeID.ToString()+"]" + sqlEx.Message;
            }

        }


    }
}
