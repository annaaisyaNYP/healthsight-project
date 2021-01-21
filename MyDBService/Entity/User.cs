using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyDBService.Entity
{
    public class User
    {
        // Initialize Properties
        public string Email { get; set; }
        public static string FinalHash { get; set; }
        public static string Salt { get; set; }
        public byte[] Key { get; set; }
        public byte[] IV { get; set; }

        public User() { }

        // Define a constructor to initialize all the properties
        public User(string email, string finalhash, string salt, byte[] key, byte[] iv)
        {
            Email = email;
            FinalHash = finalhash;
            Salt = salt;
            Key = key;
            IV = iv;
        }

        public int Insert()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDPDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 2 - Create a SqlCommand object to add record with INSERT statement
            string sqlStmt = "INSERT INTO User(email,finalhash,salt,key,iv)" +
                "VALUES (@paraEmail,@paraFinalHash,@paraSalt,@paraKey,@paraIV)";
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@paraEmail", Email);
            sqlCmd.Parameters.AddWithValue("@paraFinalHash", FinalHash);
            sqlCmd.Parameters.AddWithValue("@paraSalt", Salt);
            sqlCmd.Parameters.AddWithValue("@paraKey", Convert.ToBase64String(Key));
            sqlCmd.Parameters.AddWithValue("@paraIV", Convert.ToBase64String(IV));

            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;
        }

        public User SelectByEmail(string email)
        {
            //Step 1 -  Define a connection to the database by getting the connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDPDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlstmt = "Select * from Patient where email = @paraEmail";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraEmail", email);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            int rec_cnt = ds.Tables[0].Rows.Count;
            User obj = null;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string finalhash = row["finalhash"].ToString();
                string salt = row["salt"].ToString();
                //byte[] key = (row["key"]);
                //byte[] iv = row["iv"];
 
                //obj = User(email, FinalHash, Salt, Key, IV);
            }
            return obj;
        }
    }
}
