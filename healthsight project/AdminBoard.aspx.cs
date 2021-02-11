using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI.WebControls;
using healthsight_project.MyDBServiceReference;

namespace healthsight_project
{
    public partial class AdminBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RefreshGridView();
            lbMsg.Text = "";
        }

        private void RefreshGridView()
        {
            List<Patient> pList = new List<Patient>();
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            pList = client.GetAllPatients().ToList<Patient>();

            // using gridview to bind to the list of employee objects
            GVRegisteredUsers.DataSource = pList;
            GVRegisteredUsers.DataBind();
        }

        protected void GVRegisteredUsers_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            // If multiple ButtonField column fields are used, use the
            // CommandName property to determine which button was clicked.
            if (e.CommandName == "Remove")
            {

                // Convert the row index stored in the CommandArgument
                // property to an Integer.
                int index = Convert.ToInt32(e.CommandArgument);

                // Get the last name of the selected author from the appropriate
                // cell in the GridView control.
                GridViewRow selectedRow = GVRegisteredUsers.Rows[index];
                TableCell TableEmail = selectedRow.Cells[3];
                string email = TableEmail.Text;

                if (email == "admin@enterprise.com")
                {
                    lbMsg.Text += "Admin user cannot be deleted.";
                }
                else
                {
                    PanelDelete.Visible = Visible;
                    Session["DeleteAccByEmail"] = email;
                    lbAlert.Text += "You are about to delete the account linked to " + email ;
                }
            }
        }

        protected void btnDeleteAccYes_Click(object sender, EventArgs e)
        {
            if (!IsPasswordCorrect(Session["LoggedIn"].ToString(), tbConPass.Text))
            {
                lbAlert1.Text = "Incorrect Password. ";
            }
            else
            {
                DeleteAccount(Session["DeleteAccByEmail"].ToString());
                PanelDelete.Visible = false;
            }
        }

        protected void btnDeleteAccNo_Click(object sender, EventArgs e)
        {
            PanelDelete.Visible = false;
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

        public void DeleteAccount(string email)
        {
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            int RemovePatient = client.DeletePatientByEmail(email);
            int RemoveUser = client.DeleteUserByEmail(email);

            if (RemovePatient == 0 || RemoveUser == 0)
            {
                PanelDelete.Visible = false;
                lbMsg.Text += "Deleting user failed";
            }
            else
            {
                PanelDelete.Visible = false;
                lbMsg.Text += "User with " + email + " has been deleted.";
            }
            RefreshGridView();
        }
    }
}