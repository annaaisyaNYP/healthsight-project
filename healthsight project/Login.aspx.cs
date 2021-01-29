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
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            lbMsg.Text = "";
        }

        public bool ValidateLogin()
        {
            if (!IsEmailValid(tbEmail.Text))
            {
                lbMsg.Text += "Email is invalid! Check formatting. </br>";
            }

            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            User userEmail = client.GetUserByEmail(tbEmail.Text);
            if (userEmail == null)
            {
                lbMsg.Text += "Email does not exist in the system! </br>";
            }

            if (!IsPasswordCorrect(tbEmail.Text, tbPass.Text))
            {
                lbMsg.Text += "Password is incorrect! </br>";
            }

            // All Clear:
            if (String.IsNullOrEmpty(lbMsg.Text))
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

        protected void BtnLogin_Click(object sender, EventArgs e)
        {           
            bool validLogin = ValidateLogin();

            if (validLogin)
            {
                MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
                User userData = client.GetUserByEmail(tbEmail.Text);
                if (userData.Email == "admin@enterprise.com")
                {
                    Session["LoggedIn"] = userData.Email;

                    string guid = Guid.NewGuid().ToString();
                    Session["AuthToken"] = guid;

                    Response.Cookies.Add(new HttpCookie("AuthToken", guid));

                    Response.Redirect("AdminBoard.aspx");
                }

                else
                {
                    Session["LoggedIn"] = userData.Email;

                    string guid = Guid.NewGuid().ToString();
                    Session["AuthToken"] = guid;

                    Response.Cookies.Add(new HttpCookie("AuthToken", guid));

                    Response.Redirect("UserBoard.aspx");
                }
            }
        }
    }
}