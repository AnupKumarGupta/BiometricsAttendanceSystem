using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_EditEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmployeeId"] != null)
        {
            if (!IsPostBack)
            {
                BindDropDowns();
                setControlValues();
            }
        }
        else
            Response.Redirect("ViewEmployee.aspx");
    }
    protected void lnkUpdateEmployee_Click(object sender, EventArgs e)
    {
        Employees objEmployee = new Employees();
        objEmployee.Id = Convert.ToInt32(Session["EmployeeId"] == null ? 0 : Session["EmployeeId"]);
        objEmployee.DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text);
        objEmployee.JoiningDate = Convert.ToDateTime(txtDateOfJoining.Text);
        objEmployee.ContactNumber = Convert.ToInt64(txtContactNumber.Text);
        objEmployee.RoleId = Convert.ToInt32(ddlRoles.SelectedValue);
        objEmployee.DepartmentId = Convert.ToInt32(ddlRoles.SelectedValue);
        objEmployee.Password = txtPassword.Text;
        objEmployee.Gender = rdrbtnMale.Checked == true ? "Male" : "Female";
        ManageEmployees objManageEmployees = new ManageEmployees();
        objManageEmployees.UpdateEmployee(objEmployee);
        Response.Redirect("ViewEmployee.aspx");
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
    }
    protected void setControlValues()
    {
        ManageEmployees objManageEmployees = new ManageEmployees();
        Employees objEmployee = objManageEmployees.GetEmployeeById(Convert.ToInt64(Session[0].ToString()));
        txtName.Text = objEmployee.Name;
        rdrbtnMale.Checked = objEmployee.Gender == "NULL" ? true : objEmployee.Gender == "Male" ? true : false;
        rdrbtnFemale.Checked = rdrbtnMale.Checked ? false : true;
        txtDateOfBirth.Text = objEmployee.DateOfBirth == new DateTime() ? "" : objEmployee.DateOfBirth.ToString("d");
        txtDateOfJoining.Text = objEmployee.JoiningDate == new DateTime() ? "" : objEmployee.JoiningDate.ToString("d");
        txtContactNumber.Text = objEmployee.ContactNumber == 0 ? "" : objEmployee.ContactNumber.ToString();
        ddlDepartments.SelectedValue = objEmployee.DepartmentId.ToString();
        ddlRoles.SelectedValue = objEmployee.RoleId.ToString();
        txtPassword.Text = objEmployee.Password == "NULL" ? "" : objEmployee.Password;
    }
}