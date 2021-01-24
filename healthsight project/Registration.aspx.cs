using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using healthsight_project.MyDBServiceReference;
using System.Globalization;
using System.Text.RegularExpressions;

namespace healthsight_project
{
    public partial class Registration : Page
    {
        //Password Salt and Key initialisation
        //string EDPDBConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["EDPDB"].ConnectionString;
        static string finalHash;
        static string salt;
        byte[] Key;
        byte[] IV;

        protected void Page_Load(object sender, EventArgs e)
        {
            lbMsg.Text = "";
            lbEmailER.Text = "";
            lbPassER.Text = "";
            lbConPassER.Text = "";
        }

        private bool ValidateInput()
        {
            // INPUT REQURIED ERROR MSGS
            if (tbName.Text == "")
            {
                lbMsg.Text += "Full Name is required! </br>";
            }
            
            if (ddGender.SelectedIndex == 0)
            {
                lbMsg.Text += "A gender must be selected! </br>";
            }

            if (ddNationality.SelectedIndex == 0)
            {
                lbMsg.Text += "A nationality must be selected! </br>";
            }

            if (tbNRIC.Text == "")
            {
                lbMsg.Text += "ID/NRIC is required! </br>";
            }

            if (tbAddr.Text == "")
            {
                lbMsg.Text += "Address is required! </br>";
            }

            if (tbEmail.Text == "")
            {
                lbMsg.Text += "Email is required! </br>";
            }

            if (tbPhoneNo.Text == "")
            {
                lbMsg.Text += "Phone No. is required! </br>";
            }

            if (tbPass.Text == "")
            {
                lbMsg.Text += "Password is required! </br>";
            }

            // DOB VALIDATION
            //  - Make sure date is not from the future
            //  - Make sure user is at least 16 years old             
            if (!ValidateDOB(tbDOB.Text))
            {
                lbMsg.Text += "Date of Birth is invalid! Minimum age requirement: 16 years old." + "<br/>";
            }
            
            // NRIC VALIDATION
            if (!IsNRICValid(tbNRIC.Text))
            {
                lbMsg.Text += "NRIC is not valid! </br>";
            }

            // NRIC ERROR MSG 
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            Patient patient = client.GetPatientByNRIC(tbNRIC.Text);
            if (patient != null)
            {
                lbMsg.Text += "NRIC already exists! </br>";
            }

            // EMAIL VALIDATION
            if (!IsEmailValid(tbEmail.Text))
            {
                lbEmailER.Text += "Email is invalid! Check formatting. </br>";
            }

            // EMAIL ERROR MSG
            Patient patientEmail = client.GetPatientByEmail(tbEmail.Text);
            if (patientEmail != null)
            {
                lbEmailER.Text += "Email already exists in the system! </br>";
            }

            // PASSWORD VALIDATION
            if (!IsPasswordValid(tbPass.Text))
            {
                lbPassER.Text += "Password does not follow the requirements";
            }

            if (tbPass.Text != tbConfrimPass.Text)
            {
                lbConPassER.Text += "Passwords do not match";
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

        public bool ValidateDOB(string dob)
        {
            bool result;
            result = DateTime.TryParse(dob, out _);
            if (!result) 
            {
                return false;
            }

            // Check if date is invalid AKA from the future
            DateTime DOB = Convert.ToDateTime(dob);
            DateTime now = DateTime.Today;
            if (now <= DOB)
            {
                return false;
            }

            // Check age
            int age = ComputeAge(dob);
            if (age < 16 || age >= 100)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
        public int ComputeAge(string dob)
        {
            DateTime DOB = Convert.ToDateTime(dob);
            // Compute age
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


        // Taken from https://chrismemo.wordpress.com/2015/03/03/how-to-validate-nric-or-fin-using-c/
        private static readonly int[] Multiples = { 2, 7, 6, 5, 4, 3, 2 };
        public static bool IsNRICValid(string nric)
        {
            if (string.IsNullOrEmpty(nric))
            {
                return false;
            }

            //	check length must be 9 digits
            if (nric.Length != 9)
            {
                return false;
            }

            int total = 0
                , count = 0
                , numericNric;
            char first = nric[0]
                , last = nric[nric.Length - 1];

            // first chat alwatas T or S
            if (first != 'S' && first != 'T')
            {
                return false;
            }

            // ensure first chars is char and last

            if (!int.TryParse(nric.Substring(1, nric.Length - 2), out numericNric))
            {
                return false;
            }

            while (numericNric != 0)
            {
                total += numericNric % 10 * Multiples[Multiples.Length - (1 + count++)];

                numericNric /= 10;
            }

            char[] outputs;
            // first S, pickup different array (read specification)
            if (first == 'S')
            {
                outputs = new char[] { 'J', 'Z', 'I', 'H', 'G', 'F', 'E', 'D', 'C', 'B', 'A' };
            }
            // T pickup different arrary (read specification)
            else
            {
                outputs = new char[] { 'G', 'F', 'E', 'D', 'C', 'B', 'A', 'J', 'Z', 'I', 'H' };
            }

            return last == outputs[total % 11];

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
                return Regex.IsMatch(pwd, @"^.*(?=.{12,})(?=.+\d)(?=.+[a-z])(?=.+[A-Z])(?=.+[!*@#$%^&+=]).*",
                    RegexOptions.None, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        protected void btnSignUp_OnClick(object sender, EventArgs e)
        {
            bool validinput = ValidateInput();

            if (validinput)
            {
                //Encrypting Password
                string pwd = tbPass.Text.ToString().Trim(); ;

                //Generate random "salt"
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                byte[] saltByte = new byte[8];

                //Fills array of bytes with a cryptographically strong sequence of random values.
                rng.GetBytes(saltByte);
                salt = Convert.ToBase64String(saltByte);

                SHA512Managed hashing = new SHA512Managed();

                string pwdWithSalt = pwd + salt;

                byte[] plainHash = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwd));
                byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwdWithSalt));
                finalHash = Convert.ToBase64String(hashWithSalt); 
                // use finalHash when creating user

                RijndaelManaged cipher = new RijndaelManaged();
                cipher.GenerateKey();
                Key = cipher.Key;
                IV = cipher.IV;
                // Converting to string for easy storage into database
                string Key64 = Convert.ToBase64String(Key);
                string IV64 = Convert.ToBase64String(IV);

                //Create User
                MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
                int resultU = client.CreateUser(tbEmail.Text, finalHash, salt, Key64, IV64);

                //Create User & Patient
                DateTime dob = Convert.ToDateTime(tbDOB.Text);
                double phoneNo = Convert.ToDouble(tbPhoneNo.Text);
                string encryptNRIC = Convert.ToBase64String(encryptData(tbNRIC.Text));
                                                
                int result = client.CreatePatient(tbName.Text, encryptNRIC, dob, ddGender.SelectedValue, ddNationality.SelectedValue, tbAddr.Text, tbAllergies.Text, tbEmail.Text, phoneNo);
                
                if (result == 1)
                {
                    Response.Redirect("Success.aspx");
                }                
            }
        }

        // Encrypting NRIC
        protected byte[] encryptData(string data)
        {
        byte[] cipherText = null;
            try
            {
        RijndaelManaged cipher = new RijndaelManaged();
        cipher.IV = IV;
        cipher.Key = Key;
        ICryptoTransform encryptTransform = cipher.CreateEncryptor();
        ICryptoTransform decryptTransform = cipher.CreateDecryptor();
        byte[] plainText = Encoding.UTF8.GetBytes(data);
        cipherText = encryptTransform.TransformFinalBlock(plainText, 0, plainText.Length);
        }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
        }
            finally { }
            return cipherText;
        }
    }
}