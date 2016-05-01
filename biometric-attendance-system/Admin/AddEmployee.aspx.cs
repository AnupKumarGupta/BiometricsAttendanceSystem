using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.UnobtrusiveValidationMode = 0;
        BindDropDowns();
        //this.UnobtrusiveValidationMode = 0;

    }
    
    protected void btnSUbmit_Click(object sender, EventArgs e)
    {
        Employees objEmployee = new Employees();
        objEmployee.Id = Convert.ToInt32(txtEmployeeId.Text);
        objEmployee.Name = txtName.Text;
        objEmployee.DepartmentId = Convert.ToInt32(ddlDepartments.SelectedValue.ToString());
        objEmployee.RoleId = Convert.ToInt32(ddlRoles.SelectedValue.ToString());
        objEmployee.CreatedOn = DateTime.Now;
        objEmployee.UpdatedOn = DateTime.Now;
        objEmployee.JoiningDate = Convert.ToDateTime(txtDateOfJoining.Text);
        long contact = new long();
        long.TryParse(txtContactNumber.Text, out contact);
        objEmployee.ContactNumber = contact;
        objEmployee.Gender = rdrbtnFemale.Checked ? "Female" : "Male";
        objEmployee.ShiftId = Convert.ToInt32(ddlRoles.SelectedValue.ToString());
        ManageEmployees objManageEmployee = new ManageEmployees();
        objManageEmployee.CreateEmployee(objEmployee);
        Response.Redirect(Request.Url.AbsoluteUri);
    }

    protected void BindDropDowns()
    {
        MasterEntries objMasterEntries = new MasterEntries();
        ddlDepartments.DataSource = objMasterEntries.GetAllDepartments();
        ddlDepartments.DataTextField = "Name";
        ddlDepartments.DataValueField = "Id";
        ddlDepartments.DataBind();
        ddlRoles.DataSource = objMasterEntries.GetAllRoles();
        ddlRoles.DataTextField = "Name";
        ddlRoles.DataValueField = "Id";
        ddlRoles.DataBind();
        ddlShifts.DataSource = objMasterEntries.GetAllShifts();
        ddlShifts.DataTextField = "Name";
        ddlShifts.DataValueField = "Id";
        ddlShifts.DataBind();
    }
}