using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ViewEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindgrdEmployee();
    }

    protected void BindgrdEmployee()
    {
        ManageEmployees objManageEmployee = new ManageEmployees();
        grdEmployee.DataSource = objManageEmployee.GetAllEmployees();
        grdEmployee.DataBind();
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        Session["EmployeeId"] = btn.CommandArgument;
        Response.Redirect("EditEmployee.aspx");
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        ManageEmployees objManageEmployee = new ManageEmployees();
        objManageEmployee.DeleteEmployee(Convert.ToInt64(btn.CommandArgument));
        BindgrdEmployee();
    }
}