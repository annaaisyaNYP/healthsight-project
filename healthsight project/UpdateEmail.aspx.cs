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
    public partial class UpdateEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbMsg.Text = "";
        }

        protected void btnUpdEmail_Click(object sender, EventArgs e)
        {
            bool emailValid = ValidateEmail();

            if (emailValid)
            {
                string currEmail = Session["LoggedIn"].ToString();
                string newEmail = tbEmail.Text.ToString().Trim();

                MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
                int patient = client.UpdatePatientEmail(currEmail, newEmail);
                int user = client.UpdateUserEmail(currEmail, newEmail);

                if (patient == 1 && user == 1)
                {
                    Response.Redirect("UserSettings.aspx");
                }
            }
        }

        public bool ValidateEmail()
        {
            string email = Session["LoggedIn"].ToString();

            if (!IsEmailValid(tbEmail.Text))
            {
                lbMsg.Text += "Invalid Email. </br>";
            }

            if (!IsPasswordCorrect(email, tbConPass.Text))
            {
                lbMsg.Text += "Incorrect password. </br>";
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

        // Taken from https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format
        public static bool IsEmailValid(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
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