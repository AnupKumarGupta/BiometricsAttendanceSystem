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
        DataTable dt = new DataTable();
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;

        List<SqlParameter> list_params = new List<SqlParameter>()
            {
            new SqlParameter("@employeeId", Convert.ToInt32(txtEmployeeId.Text)),
            new SqlParameter("@password",txtPassword.Text)
            };
        try
        {
            using (DBDataHelper helper = new DBDataHelper())
            {
                string query = "select * from tblEmployees where EmployeeId=@employeeId and Password=@password";
                dt = helper.GetDataTable(query, SQLTextType.Query, list_params);
                if (dt.Rows.Count == 1)
                {
                    int RoleId = Convert.ToInt32(dt.Rows[0]["RoleId"]);
                    Session["employeeId"] = txtEmployeeId.Text;
                    Session["roleId"] = RoleId;
                    if (RoleId == 1)
                        Response.Redirect("~/Admin/ManageMasterEntries.aspx", false);
                    else
                        Response.Redirect("~/Admin/ManageMasterEntries.aspx", false);
                }
                else
                {
                    lblMessage.Text = "Invalid User Id or Password";
                }
            }
        }

        catch(Exception ex)
        {
            Console.WriteLine("{0}", ex);
        }

    }
}