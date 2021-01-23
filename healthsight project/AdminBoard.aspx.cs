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
    }
}