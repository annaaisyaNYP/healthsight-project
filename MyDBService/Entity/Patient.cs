using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;

namespace MyDBService.Entity
{
    public class Patient
    {
        // Initialize Properties
        public String Name { get; set; }
        public String NRIC { get; set; }
        public DateTime DOB { get; set; }
        public String Gender { get; set; }
        public String Nat { get; set; }
        public String Addr { get; set; }
        public String MedCon { get; set; }
        public String Email { get; set; }

        public Double PhoneNo { get; set; }

        public Patient() { }

        // Define a constructor to initialize all the properties
        public Patient(string name, string nric, DateTime dob, string gen, string nat, string addr, string medcon, string email, double phoneNo)
        {
            Name = name;
            NRIC = nric;
            DOB = dob;
            Gender = gen;
            Nat = nat;
            Addr = addr;
            MedCon = medcon;
            Email = email;
            PhoneNo = phoneNo;
        }

        public int ComputeAge()
        {
            DateTime now = DateTime.Today;
            int age = DateTime.Today.Year - DOB.Year;
            if (now.Month < DOB.Month)
            {
                age--;
            }
            else
            {
                if (now.Month == DOB.Month && now.Day < DOB.Day)
                {
                    age--;
                }
            }
            return age;
        }

        public int Insert()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDPDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 2 - Create a SqlCommand object to add record with INSERT statement
            string sqlStmt = "INSERT INTO Patient(name, nric, dob, gender, nationality, addr, medcon, email, phoneNo)" +
                "VALUES (@paraName, @paraNric, @paraDob, @paraGen, @paraNat, @paraAddr, @paraMedcon, @paraEmail, @paraPhoneNo)";
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@paraNric", Convert.FromBase64String(NRIC));
            sqlCmd.Parameters.AddWithValue("@paraName", Name);
            sqlCmd.Parameters.AddWithValue("@paraDob", DOB);
            sqlCmd.Parameters.AddWithValue("@paraGen", Gender);
            sqlCmd.Parameters.AddWithValue("@paraNat", Nat);
            sqlCmd.Parameters.AddWithValue("@paraAddr", Addr);
            if (MedCon == null)
            {
                sqlCmd.Parameters.AddWithValue("@paraMedcon", DBNull.Value);
            }
            else
            {
                sqlCmd.Parameters.AddWithValue("@paraMedcon", MedCon);
            }
            sqlCmd.Parameters.AddWithValue("@paraEmail", Email);
            sqlCmd.Parameters.AddWithValue("@paraPhoneNo", PhoneNo);


            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;
        }

        // TODO: Decrypt NRIC to compare OR is this redundant?
        public Patient SelectByNRIC(string nric)
        {
            //Step 1 -  Define a connection to the database by getting the connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDPDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlstmt = "Select * from Patient where nric = @paraNric";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraNric", nric);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            int rec_cnt = ds.Tables[0].Rows.Count;
            Patient obj = null;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string name = row["name"].ToString();
                DateTime dob = Convert.ToDateTime(row["dob"].ToString());
                string gen = row["gender"].ToString();
                string nat = row["nationality"].ToString();
                string address = row["addr"].ToString();
                string medcon = row["medcon"].ToString();
                string email = row["email"].ToString();
                string pnStr = row["phoneNo"].ToString();
                double phoneNo = Convert.ToDouble(pnStr);

                obj = new Patient(nric, name, dob, gen, nat, address, medcon, email, phoneNo);
            }
            return obj;
        }

        public Patient SelectByEmail(string email)
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
            Patient obj = null;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string nric = row["nric"].ToString();
                string name = row["name"].ToString();
                DateTime dob = Convert.ToDateTime(row["dob"].ToString());
                string gen = row["gender"].ToString();
                string nat = row["nationality"].ToString();
                string address = row["addr"].ToString();
                string medcon = row["medcon"].ToString();
                string pnStr = row["phoneNo"].ToString();
                double phoneNo = Convert.ToDouble(pnStr);

                obj = new Patient(nric, name, dob, gen, nat, address, medcon, email, phoneNo);
            }
            return obj;
        }

        public List<Patient> SelectAll()
        {
            //Step 1 -  Define a connection to the database by getting the connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDPDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlstmt = "Select * from Patient";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            int rec_cnt = ds.Tables[0].Rows.Count;
            List<Patient> pList = new List<Patient>();
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string nric = row["nric"].ToString();
                string name = row["name"].ToString();
                DateTime dob = Convert.ToDateTime(row["dob"].ToString());
                string gen = row["gender"].ToString();
                string nat = row["nationality"].ToString();
                string address = row["addr"].ToString();
                string medcon = row["medcon"].ToString();
                string email = row["email"].ToString();
                string pnStr = row["phoneNo"].ToString();
                double phoneNo = Convert.ToDouble(pnStr);

                Patient obj = new Patient(nric, name, dob, gen, nat, address, medcon, email, phoneNo);
                pList.Add(obj);
            }
            return pList;
        }

        // Sorting Methods

        public List<Patient> OrderByNameASC()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["EDPDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from Patient ORDER BY Name ASC";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);

            DataSet ds = new DataSet();

            da.Fill(ds);

            int rec_cnt = ds.Tables[0].Rows.Count;
            List<Patient> pList = new List<Patient>();
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                string nric = row["nric"].ToString();
                string name = row["name"].ToString();
                DateTime dob = Convert.ToDateTime(row["dob"].ToString());
                string gen = row["gender"].ToString();
                string nat = row["nationality"].ToString();
                string address = row["addr"].ToString();
                string medcon = row["medcon"].ToString();
                string email = row["email"].ToString();
                string pnStr = row["phoneNo"].ToString();
                double phoneNo = Convert.ToDouble(pnStr);

                Patient obj = new Patient(nric, name, dob, gen, nat, address, medcon, email, phoneNo);
                pList.Add(obj);
            }
            return pList;
        }

        public List<Patient> OrderByNameDESC()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["EDPDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from Patient ORDER BY Name DESC";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);

            DataSet ds = new DataSet();

            da.Fill(ds);

            int rec_cnt = ds.Tables[0].Rows.Count;
            List<Patient> pList = new List<Patient>();
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                string nric = row["nric"].ToString();
                string name = row["name"].ToString();
                DateTime dob = Convert.ToDateTime(row["dob"].ToString());
                string gen = row["gender"].ToString();
                string nat = row["nationality"].ToString();
                string address = row["addr"].ToString();
                string medcon = row["medcon"].ToString();
                string email = row["email"].ToString();
                string pnStr = row["phoneNo"].ToString();
                double phoneNo = Convert.ToDouble(pnStr);

                Patient obj = new Patient(nric, name, dob, gen, nat, address, medcon, email, phoneNo);
                pList.Add(obj);
            }
            return pList;
        }

        // Update Methods
        public int UpdateEmail(string CurrEmail, string NewEmail)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["EDPDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE Patient SET email = @paraNewEmail where email = @paraCurrEmail";

            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            //sqlCmd.Parameters.AddWithValue("@para",);
            sqlCmd.Parameters.AddWithValue("@paraNewEmail", NewEmail);
            sqlCmd.Parameters.AddWithValue("@paraCurrEmail", CurrEmail);

            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        // TODO: Add more update methods - Address and Phone No.

        // Delete Method
        public int DeletePatientByEmail(string email)
        {            
            if (SelectByEmail(email) != null)
            {
                string DBConnect = ConfigurationManager.ConnectionStrings["EDPDB"].ConnectionString;
                SqlConnection myConn = new SqlConnection(DBConnect);

                string sqlStmt = "DELETE FROM Patient WHERE email = @paraEmail;";

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
