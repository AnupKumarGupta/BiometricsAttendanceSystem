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
    protected string imagePath(string employeeName)
    {
        string fileName;
        if (fileUploadProfilePic.HasFile)
        {
            fileName = Path.GetFileName(fileUploadProfilePic.PostedFile.FileName);
            fileUploadProfilePic.PostedFile.SaveAs(Server.MapPath("~/Images/") + fileName);
            return fileName;
        }
        else
            return String.Empty;
    }
    protected void btnSUbmit_Click(object sender, EventArgs e)
    {
        Employees objEmployee = new Employees();
        objEmployee.Id = 0; //Mapped From Device
        objEmployee.Name = txtName.Text;
        objEmployee.DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text);
        objEmployee.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedValue.ToString());
        objEmployee.RoleId = Convert.ToInt32(ddlRole.SelectedValue.ToString());
        objEmployee.CreatedOn = DateTime.Now;
        objEmployee.UpdatedOn = DateTime.Now;
        objEmployee.JoiningDate = Convert.ToDateTime(txtDateOfJoining.Text);
        objEmployee.ImagePath = imagePath(objEmployee.FirstName + objEmployee.LastName);
        objEmployee.Password = txtPassword.Text;
        long contact = new long();
        long.TryParse(txtContactNumber.Text, out contact);
        objEmployee.ContactNumber = contact;
        objEmployee.Gender = rdrbtnFemale.Checked ? "Female" : "Male";
        ManageEmployees objManageEmployee = new ManageEmployees();
        objManageEmployee.CreateEmployee(objEmployee);
        Response.Redirect(Request.Url.AbsoluteUri);
    }

    protected void BindDropDowns()
    {
        MasterEntries objMasterEntries = new MasterEntries();
        ddlDepartment.DataSource = objMasterEntries.GetAllDepartments();
        ddlDepartment.DataTextField = "Name";
        ddlDepartment.DataValueField = "Id";
        ddlDepartment.DataBind();
        ddlRole.DataSource = objMasterEntries.GetAllRoles();
        ddlRole.DataTextField = "Name";
        ddlRole.DataValueField = "Id";
        ddlRole.DataBind();
    }
}