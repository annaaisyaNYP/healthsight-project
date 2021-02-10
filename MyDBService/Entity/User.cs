﻿using System;
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
        public string FinalHash { get; set; }
        public string Salt { get; set; }
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
                string finalhash = row["PassHash"].ToString();
                string salt = row["PassSalt"].ToString();
                // string key = row["key"].ToString();
                // string iv = row["iv"].ToString();
                string key = "";
                string iv = "";

                obj = new User(email, finalhash, salt, key, iv);
            }
            return obj;
        }

        // Update Methods
        public int UpdateEmail(string CurrEmail, string NewEmail)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["EDPDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE [User] SET email = @paraNewEmail WHERE email = @paraCurrEmail";

            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            //sqlCmd.Parameters.AddWithValue("@para",);
            sqlCmd.Parameters.AddWithValue("@paraNewEmail", NewEmail);
            sqlCmd.Parameters.AddWithValue("@paraCurrEmail", CurrEmail);

            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public int UpdatePassword(string email, string finalhash, string salt, string key, string iv)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["EDPDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE [User] SET passHash = @PassHash, passSalt = @PassSalt, " +
                    "[key] = @Key, IV = @IV WHERE email = @Email";
            SqlCommand cmd = new SqlCommand(sqlStmt, myConn);

            cmd.Parameters.AddWithValue("@Email",email);
            cmd.Parameters.AddWithValue("@PassHash", finalhash);
            cmd.Parameters.AddWithValue("@PassSalt", salt);
            cmd.Parameters.AddWithValue("@Key", key);
            cmd.Parameters.AddWithValue("@IV",iv);

            myConn.Open();
            int result = cmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        // Delete Method
        public int DeleteUserByEmail(string email)
        {
            if (SelectByEmail(email) != null)
            {
                string DBConnect = ConfigurationManager.ConnectionStrings["EDPDB"].ConnectionString;
                SqlConnection myConn = new SqlConnection(DBConnect);

                string sqlStmt = "DELETE FROM [User] WHERE email = @paraEmail;";

                SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

                sqlCmd.Parameters.AddWithValue("@paraEmail", email);

                myConn.Open();
                int result = sqlCmd.ExecuteNonQuery();

                myConn.Close();

                return result;
            }
            else
            {
                return -1;
            }
        }
    }
}
