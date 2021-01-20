using System;
using System.Web.UI;
using healthsight_project.MyDBServiceReference;

namespace healthsight_project
{
    public partial class Contact : Page
    {
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
                DateTime dob = Convert.ToDateTime(tbDOB.Text);
                double phoneNo = Convert.ToDouble(tbPhoneNo.Text);

                MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
                int result = client.CreatePatient(tbName.Text, tbNRIC.Text, dob, ddGender.SelectedValue, ddNationality.SelectedValue, tbAddr.Text, tbAllergies.Text, tbEmail.Text, phoneNo);
                if (result == 1)
                {
                    Response.Redirect("Success.aspx");
                }
            }
        }
    }
}