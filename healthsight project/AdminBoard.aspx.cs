using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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

        //bool ConfrimDelete()

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
                TableCell TableEmail = selectedRow.Cells[6];
                string email = TableEmail.Text;

                lbMsg.Text += "You selected " + email + ".";

                //int RemovePatient;
                //int RemoveUser;
                //MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
                //RemovePatient = client.DeletePatientByEmail(email);
                //RemoveUser = client.DeleteUserByEmail(email);

                //if(RemovePatient == 0 || RemoveUser == 0)
                //{
                //    lbMsg.Text += "Deleting user failed";
                //}
                //else
                //{
                //    lbMsg.Text += "User with " + email + " has been deleted.";
                //}
            }
        }
    }
}