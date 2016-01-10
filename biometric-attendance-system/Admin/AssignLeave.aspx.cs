using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AssignLeave : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindDropDowns();
    }
    protected void BindDropDowns()
    {
        MasterEntries objMasterEntries = new MasterEntries();
        ddlDepartment.DataSource = objMasterEntries.GetAllDepartments();
        ddlDepartment.DataTextField = "Name";
        ddlDepartment.DataValueField = "Id";
        ddlDepartment.DataBind();
    }

    protected void btnGetAllEmployess_Click(object sender, EventArgs e)
    {
        ManageEmployees objManageEmployees = new ManageEmployees();
        grdEmployee.DataSource = objManageEmployees.GetEmployeesByDepartment(Int32.Parse(ddlDepartment.SelectedValue.ToString()));
        grdEmployee.DataBind();
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Button b = (Button)sender;
        int Id = Convert.ToInt32(b.CommandArgument.Split(';')[0]);
        Session["employeeId"] = Id;
        Session["employeeName"] = b.CommandArgument.Split(';')[1];
        Response.Redirect("~/Admin/AssignLeaveToEmployee.aspx");
    }
}