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
    public partial class UpdateAddr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbMsg.Text = "";
        }
        protected void btnUpdAddr_Click(object sender, EventArgs e)
        {
            bool addrValid = ValidateAddr();
            string email = Session["LoggedIn"].ToString();

            if (addrValid)
            {
                MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
                int result = client.UpdatePatientAddr(email, tbAddress.Text);

                if (result == 1)
                {
                    Session["SettingsResponse"] = "Address successfully updated.";
                    Response.Redirect("UserSettings.aspx");
                }
            }
        }

        public bool ValidateAddr()
        {
            if (tbAddress.Text == "")
            {
                lbMsg.Text += "Address is required. </br>";
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