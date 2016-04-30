using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DALHelper;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {


            string username = txtEmployeeId.Text;
            string pass = txtPassword.Text;
            if (username == "Admin" && pass == "12345")
            {
                Session["employeeId"] = username;
                Response.Redirect("~/Admin/ManageMasterEntries.aspx", false);
            }
            else
            {
                lblMessage.Text = "Invalid User Id or Password";
            }
        }

        catch (Exception ex)
        {
            Console.WriteLine("{0}", ex);
        }

    }
}