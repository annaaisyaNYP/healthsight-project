using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

            if (tbIDno.Text == "")
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

            // ID/NRIC ERROR MSG

            // EMAIL ERROR MSG

            // PASSWORD VALIDATION

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
                Response.Redirect("Success.aspx");
            }
        }
    }
}