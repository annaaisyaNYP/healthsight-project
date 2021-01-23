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
        public string Key { get; set; }
        public string IV { get; set; }

        public User() { }

        // Define a constructor to initialize all the properties
        public User(string email, string finalhash, string salt, string key, string iv)
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
            string sqlStmt = "INSERT INTO [User](email,passhash,passsalt,[key],iv)" +
                "VALUES (@paraEmail,@paraPassHash,@paraPassSalt,@paraKey,@paraIV)";
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@paraEmail", Email);
            sqlCmd.Parameters.AddWithValue("@paraPassHash", FinalHash);
            sqlCmd.Parameters.AddWithValue("@paraPassSalt", Salt);
            sqlCmd.Parameters.AddWithValue("@paraKey", Convert.FromBase64String(Key));
            sqlCmd.Parameters.AddWithValue("@paraIV", Convert.FromBase64String(IV));

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
            string sqlstmt = "Select * from [User] where email = @paraEmail";
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
                string finalhash = row["passHash"].ToString();
                string salt = row["passSalt"].ToString();
                string key = row["key"].ToString();
                string iv = row["iv"].ToString();

                obj = new User(email, finalhash, salt, key, iv);
            }
            return obj;
        }
    }
}
