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
            lbUpdEmailEr.Text = "";
            lbUpdPassEr.Text = "";
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
        }

        protected void btnUpdEmail_Click(object sender, EventArgs e)
        {
            bool validEmail = ValidateEmail();

            if (validEmail)
            {
                MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
                int patient = client.UpdatePatientEmail(lbCurrEmail.Text, tbEmail.Text);
                int user = client.UpdateUserEmail(lbCurrEmail.Text, tbEmail.Text);
            }
        }

        public bool ValidateEmail()
        {
            if (tbEmail.Text == "")
            {
                lbUpdEmailEr.Text += "Email is required! </br>";
            }

            if (!IsEmailValid(tbEmail.Text))
            {
                lbUpdEmailEr.Text += "Email is invalid! Check formatting. </br>";
            }

            if (!IsPasswordCorrect(lbCurrEmail.Text, tbConPass4Email.Text))
            {
                lbUpdEmailEr.Text += "Password is incorrect! </br>";
            }

            // All Clear:
            if (String.IsNullOrEmpty(lbUpdEmailEr.Text))
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
    }
}