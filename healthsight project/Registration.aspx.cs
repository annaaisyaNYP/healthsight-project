using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using healthsight_project.MyDBServiceReference;

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

        }

        private bool ValidateInput()
        {
            // INPUT REQURIED ERROR MSGS
            bool result;
            if (tbName.Text == "")
            {
                lbMsg.Text += "Full Name is required! </br>";
            }

            DateTime dob;
            result = DateTime.TryParse(tbDOB.Text, out dob);
            if (!result)
            {
                lbMsg.Text += "Date of Birth is invalid!" + "<br/>";
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

            // NRIC ERROR MSG 
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            Patient patient = client.GetPatientByNRIC(tbNRIC.Text);
            if (patient != null)
            {
                lbMsg.Text += "NRIC already exists! </br>";
            }

            // EMAIL ERROR MSG
            Patient patientEmail = client.GetPatientByEmail(tbEmail.Text);
            if (patientEmail != null)
            {
                lbEmailER.Text += "Email already exists in the system! </br>";
            }

            // PASSWORD VALIDATION
            // if (tbPass.text [does not contain either 1 lowercase, 1 uppercase, 1 number and 12 minimum characters])
            //{
            //lbPassER.Text += "Password does not follow the requiements";
            //}

            if (tbPass.Text != tbConfrimPass.Text)
            {
                lbConPassER.Text += "Passwords do not match";
            }


            if (String.IsNullOrEmpty(lbMsg.Text))
            {
                return true;
            }
            else
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

                //Create User
                MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
                //int resultA = client.CreateUser(tbEmail.Text,finalHash,salt,IV,Key)

                //Create Patient
                DateTime dob = Convert.ToDateTime(tbDOB.Text);
                double phoneNo = Convert.ToDouble(tbPhoneNo.Text);

                if (tbAllergies.Text == "")
                {
                    string MedCon = "Null";
                    int result = client.CreatePatient(tbName.Text, tbNRIC.Text, dob, ddGender.SelectedValue, ddNationality.SelectedValue, tbAddr.Text, MedCon, tbEmail.Text, phoneNo);

                    if (result == 1)
                    {
                        Response.Redirect("Success.aspx");
                    }
                }
                else
                {
                    int result = client.CreatePatient(tbName.Text, tbNRIC.Text, dob, ddGender.SelectedValue, ddNationality.SelectedValue, tbAddr.Text, tbAllergies.Text, tbEmail.Text, phoneNo);

                    if (result == 1)
                    {
                        Response.Redirect("Success.aspx");
                    }
                }
            }
        }

        // Encrypting NRIC
        //protected byte[] encryptData(string data)
        //{
        //byte[] cipherText = null;
        //    try
        //    {
        //RijndaelManaged cipher = new RijndaelManaged();
        //cipher.IV = IV;
        //cipher.Key = Key;
        //ICryptoTransform encryptTransform = cipher.CreateEncryptor();
        //ICryptoTransform decryptTransform = cipher.CreateDecryptor();
        //byte[] plainText = Encoding.UTF8.GetBytes(data);
        //cipherText = encryptTransform.TransformFinalBlock(plainText, 0, plainText.Length);
        //}
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.ToString());
        //}
        //    finally { }
        //    return cipherText;
        //}
    }
}