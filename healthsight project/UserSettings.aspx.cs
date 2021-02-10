using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using healthsight_project.MyDBServiceReference;
using System.Globalization;
using System.Text.RegularExpressions;

namespace healthsight_project
{
    public partial class UserSettings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbUpdPassEr.Text = "";
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            Session["LoggedIn"].ToString();
        }

        // Created with reference from the above method
        public bool IsPasswordValid(string pwd)
        {
            if (string.IsNullOrWhiteSpace(pwd))
                return false;

            try
            {
                return Regex.IsMatch(pwd, @"^.*(?=.{8,})(?=.+\d)(?=.+[a-z])(?=.+[A-Z])(?=.+[!*@#$%^&+=]).*",
                    RegexOptions.None, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
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
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {

        }

        protected void btnEmail_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateEmail.aspx");
        }

        protected void btnPhoneNo_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateContactNo.aspx");
        }

        protected void btnAddr_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateAddr.aspx");
        }

    }
}