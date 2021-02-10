using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using healthsight_project.MyDBServiceReference;
using System.Globalization;
using System.Text.RegularExpressions;

namespace healthsight_project
{
    public partial class UpdateContactNo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbMsg.Text = "";
        }

        protected void btnUpdPhoneNo_Click(object sender, EventArgs e)
        {
            bool contactValid = ValidateContact();

            if (contactValid)
            {
                string email = Session["LoggedIn"].ToString();
                MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
                int result = client.UpdatePatientPhoneNo(email, tbPhoneNo.Text);

                if (result == 1)
                {
                    Response.Redirect("UserSettings.aspx");
                }

            }
        }

        public bool ValidateContact()
        {
            if (tbPhoneNo.Text.Length < 8)
            {
                lbMsg.Text += "Your contact number is too short. </br>";
            }

            if (tbPhoneNo.Text.Length > 8)
            {
                lbMsg.Text += "Your contact number is too long. </br>";
            }

            string email = Session["LoggedIn"].ToString();
            if (!IsPasswordCorrect(email, tbConPass.Text))
            {
                lbMsg.Text += "Incorrect Password. </br>";
            }

            if (lbMsg.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsPasswordCorrect(string email, string pass)
        {
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            User user = client.GetUserByEmail(email);
            SHA512Managed hashing = new SHA512Managed();
            string dbHash = user.FinalHash;
            string dbSalt = user.Salt;
            if (dbSalt != null && dbSalt.Length > 0 && dbHash != null && dbHash.Length > 0)
            {
                string passWithSalt = pass + dbSalt;
                byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(passWithSalt));
                string userHash = Convert.ToBase64String(hashWithSalt);
                if (userHash.Equals(dbHash))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}