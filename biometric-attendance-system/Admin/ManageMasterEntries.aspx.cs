using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManageMasterEntries : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["employeeId"] == null)
        {
            Response.Redirect("~/Home.aspx");
        }
        if (!IsPostBack)
        {
            pnlLeaveAssignedByRole.Visible = false;
            pnlDepartment.Visible = false;
            pnlLeave.Visible = false;
            pnlDuration.Visible = false;
            grdDepartmentBind();
            grdLeaveBind();
            grdRoleBind();
        }
    }

    #region Departments

    protected void btnDepartments_Click(object sender, EventArgs e)
    {
        pnlLeaveAssignedByRole.Visible = false;
        pnlDepartment.Visible = true;
        pnlLeave.Visible = false;
        pnlRole.Visible = false;
        pnlShifts.Visible = false;
        pnlDuration.Visible = false;
    }

    protected void lnkAddDepartment_Click(object sender, EventArgs e)
    {
        string department = txtDepartment.Text;
        MasterEntries objMasterEntry = new MasterEntries();
        objMasterEntry.AddDepartment(department);
        grdDepartmentBind();
    }

    protected void grdDepartmentBind()
    {
        MasterEntries objMasterEntries = new MasterEntries();
        grdDepartment.DataSource = objMasterEntries.GetAllDepartments();
        grdDepartment.DataBind();
    }

    protected void lkbEditDepartment_Click(object sender, EventArgs e)
    {
        MasterEntries objMasterEntry = new MasterEntries();
        LinkButton b = (LinkButton)sender;
        int Id = Convert.ToInt32(b.CommandArgument);
        string departmentName = objMasterEntry.GetDepartmentById(Id);
        txtEditDepartment.Text = departmentName;
        Session["departmentId"] = Id;
        popupEditDepartment.Show();
    }
    protected void btnUpdateDepartment_Click(object sender, EventArgs e)
    {
        MasterEntries objMasterEntry = new MasterEntries();
        string departmentName = txtEditDepartment.Text;
        int Id = Convert.ToInt32(Session["departmentId"]);
        objMasterEntry.UpdateDepartment(Id, departmentName);
        grdDepartmentBind();
        popupEditDepartment.Hide();
    }

    #endregion

    #region Leave

    protected void lnkAddLeave_Click(object sender, EventArgs e)
    {
        string leave = txtLeave.Text;
        MasterEntries objMasterEntry = new MasterEntries();
        objMasterEntry.AddTypeOfLeave(leave); // Input from Drop down
        grdLeaveBind();
    }

    protected void lkbEditLeave_Click(object sender, EventArgs e)
    {
        MasterEntries objMasterEntry = new MasterEntries();
        List<Leaves> objListLeaves = new List<Leaves>();
        LinkButton b = (LinkButton)sender;
        Leaves objLeaves = new Leaves();
        int Id = Convert.ToInt32(b.CommandArgument);
        objMasterEntry.GetLeavesById(Id, out objLeaves);
        txtEditLeave.Text = objLeaves.LeaveName;
        Session["LeaveId"] = Id;
        popupEditLeave.Show();
    }

    protected void btnUpdateLeave_Click(object sender, EventArgs e)
    {
        MasterEntries objMasterEntry = new MasterEntries();
        string leaveName = txtEditLeave.Text;
        int Id = Convert.ToInt32(Session["LeaveId"]);
        objMasterEntry.UpdateLeave(Id, leaveName);
        grdLeaveBind();
        popupEditLeave.Hide();
    }

    protected void grdLeaveBind()
    {
        MasterEntries objMasterEntries = new MasterEntries();
        grdLeave.DataSource = objMasterEntries.GetAllTypeOfLeaves();
        grdLeave.DataBind();
    }

    protected void btnLeaves_Click(object sender, EventArgs e)
    {
        pnlLeaveAssignedByRole.Visible = false;
        pnlDepartment.Visible = false;
        pnlLeave.Visible = true;
        pnlRole.Visible = false;
        pnlShifts.Visible = false;
        pnlDuration.Visible = false;
    }

    #endregion

    #region Role

    protected void lnkAddRole_Click(object sender, EventArgs e)
    {
        string role = txtRole.Text;
        MasterEntries objMasterEntry = new MasterEntries();
        objMasterEntry.AddRole(role);
        grdRoleBind();
    }

    protected void btnRoles_Click(object sender, EventArgs e)
    {
        pnlLeaveAssignedByRole.Visible = false;
        pnlDepartment.Visible = false;
        pnlRole.Visible = true;
        pnlLeave.Visible = false;
        pnlShifts.Visible = false;
        pnlDuration.Visible = false;
    }

    protected void lkbEditRole_Click(object sender, EventArgs e)
    {
        MasterEntries objMasterEntry = new MasterEntries();
        LinkButton b = (LinkButton)sender;
        int Id = Convert.ToInt32(b.CommandArgument);
        string roleName = objMasterEntry.GetRoleById(Id);
        txtEditRole.Text = roleName;
        Session["roleId"] = Id;
        popupEditRole.Show();
    }

    protected void btnUpdateRole_Click(object sender, EventArgs e)
    {
        MasterEntries objMasterEntry = new MasterEntries();
        string roleName = txtEditRole.Text;
        int Id = Convert.ToInt32(Session["roleId"]);
        objMasterEntry.UpdateRole(Id, roleName);
        grdRoleBind();
        popupEditRole.Hide();
    }

    protected void grdRoleBind()
    {
        MasterEntries objMasterEntries = new MasterEntries();
        grdRole.DataSource = objMasterEntries.GetAllRoles();
        grdRole.DataBind();
    }

    #endregion

    #region Shifts

    protected void lnkbtnShifts_Click(object sender, EventArgs e)
    {
        Shifts objShift = new Shifts();
        objShift.FirstHalfStart = TimeSpan.Parse(txtFirstHalfStart.Text);
        objShift.FirstHalfEnd = TimeSpan.Parse(txtFirstHalfEnd.Text);
        objShift.SecondHalfStart = TimeSpan.Parse(txtSecondHalfStart.Text);
        objShift.SecondHalfEnd = TimeSpan.Parse(txtSecondHalfEnd.Text);
        MasterEntries objMasterEntry = new MasterEntries();
        objMasterEntry.AddShift(objShift);
        grdShiftsBind();
    }
    protected void btnShifts_Click(object sender, EventArgs e)
    {
        pnlDepartment.Visible = false;
        pnlRole.Visible = false;
        pnlLeave.Visible = false;
        pnlLeaveAssignedByRole.Visible = false;
        pnlDuration.Visible = false;
        pnlShifts.Visible = true;
        grdShiftsBind();
    }
    protected void grdShiftsBind()
    {
        MasterEntries objMasterEntries = new MasterEntries();
        gvShifts.DataSource = objMasterEntries.GetAllShifts();
        gvShifts.DataBind();
    }

    protected void lkbEditShift_Click(object sender, EventArgs e)
    {
        MasterEntries objMasterEntry = new MasterEntries();
        LinkButton b = (LinkButton)sender;
        int Id = Convert.ToInt32(b.CommandArgument);
        Shifts objShift = new Shifts();
        
    }
    #endregion

    #region LeavesAssignedByRole

    protected void btnLeaveAssignedByRole_Click(object sender, EventArgs e)
    {
        ddlRole.Items.Clear();
        ddlRole.Items.Add("select");
        ddlLeave.Items.Clear();
        ddlLeave.Items.Add("select");
        pnlDepartment.Visible = false;
        pnlRole.Visible = false;
        pnlLeave.Visible = false;
        pnlShifts.Visible = false;
        pnlLeaveAssignedByRole.Visible = true;
        grdLeaveAssignByRoleBind();
        ddlRole.DataSource = GiveAllRole();
        ddlRole.DataTextField = "Name";
        ddlRole.DataValueField = "Id";
        ddlRole.DataBind();
        ddlLeave.DataSource = GetAllLeaves();
        ddlLeave.DataTextField = "LeaveName";
        ddlLeave.DataValueField = "Id";
        ddlLeave.DataBind();

    }

    protected void lnkAddLeaveAsssignedByRole_Click(object sender, EventArgs e)
    {

        int roleId = Convert.ToInt32(ddlRole.SelectedValue);
        int leaveId = Convert.ToInt32(ddlLeave.SelectedValue);
        int noOfLeaves = Convert.ToInt32(txtNoOfLeaves.Text);
        int isPromoted = Convert.ToInt32(ddlIsPromoted.SelectedValue);
        MasterEntries objMasterEntry = new MasterEntries();
        int count = objMasterEntry.Count(roleId, leaveId);
        if (count == 0)
            objMasterEntry.LeaveAssignedByRole(leaveId, roleId, noOfLeaves, isPromoted);
        grdLeaveAssignByRoleBind();
    }

    protected void grdLeaveAssignByRoleBind()
    {
        MasterEntries objMasterEntries = new MasterEntries();
        gvViewLeaveAssignedByRole.DataSource = objMasterEntries.GetAllTypeOfLeavesAssignedByRole();
        gvViewLeaveAssignedByRole.DataBind();
    }

    protected void lkbEditLeaveAssingedByRole_Click(object sender, EventArgs e)
    {
        ddlRole.Items.Clear();
        ddlRole.Items.Add("select");
        ddlLeave.Items.Clear();
        ddlLeave.Items.Add("select");
        ddlRole1.DataSource = GiveAllRole();
        ddlRole1.DataTextField = "Name";
        ddlRole1.DataValueField = "Id";
        ddlRole1.DataBind();
        ddlLeaveEdit.DataSource = GetAllLeaves();
        ddlLeaveEdit.DataTextField = "LeaveName";
        ddlLeaveEdit.DataValueField = "Id";
        ddlLeaveEdit.DataBind();
        MasterEntries objMasterEntry = new MasterEntries();
        LinkButton b = (LinkButton)sender;
        int Id = Convert.ToInt32(b.CommandArgument);
        string roleName = objMasterEntry.GetRoleById(Id);
        LeaveAssignedByRole objLeaves = new LeaveAssignedByRole();
        objMasterEntry.GetLeavesAssignedByRoleById(Id, out objLeaves);
        txtNoOfLeave.Text = objLeaves.NoOfLeaves.ToString();
        ddlIsPromotedEdit.SelectedIndex = Convert.ToInt32(objLeaves.IsPromoted);
        ddlRole1.SelectedIndex = Convert.ToInt32(objLeaves.RoleId);
        ddlLeaveEdit.SelectedIndex = Convert.ToInt32(objLeaves.LeaveTypeId);
        ddlRole1.Enabled = false;
        ddlLeaveEdit.Enabled = false;
        Session["Id"] = Id;
        popupEditLeaveAssignedByRole.Show();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        MasterEntries objMasterEntry = new MasterEntries();
        int noOfLeaves = Convert.ToInt32(txtNoOfLeave.Text);
        // int isPromoted = Convert.ToInt32(ddlIsPromotedEdit.SelectedIndex);
        int Id = Convert.ToInt32(Session["Id"]);
        bool isPromoted = true;
        objMasterEntry.UpdateLeavesAssignedByRole(Id, noOfLeaves, isPromoted);
        grdLeaveAssignByRoleBind();
        popupEditLeaveAssignedByRole.Hide();
    }

    protected List<Role> GiveAllRole()
    {
        MasterEntries objMasterEntries = new MasterEntries();
        List<Role> lstRole = new List<Role>();
        lstRole = objMasterEntries.GetAllRoles();
        return lstRole;
    }

    protected List<Leaves> GetAllLeaves()
    {
        MasterEntries objMasterEntries = new MasterEntries();
        List<Leaves> lstLeaves = new List<Leaves>();
        lstLeaves = objMasterEntries.GetAllTypeOfLeaves();
        return lstLeaves;
    }


    #endregion

    #region Duration

    protected void btnDuration_Click(object sender, EventArgs e)
    {
        pnlDepartment.Visible = false;
        pnlRole.Visible = false;
        pnlLeave.Visible = false;
        pnlLeaveAssignedByRole.Visible = false;
        pnlShifts.Visible = false;
        pnlDuration.Visible = true;
        GridDuration();
    }

    protected void lnkAddDuration_Click(object sender, EventArgs e)
    {
        TimeSpan duration = TimeSpan.Parse(ddlSuggestions.SelectedValue);
        int leaveId = Convert.ToInt32(ddlLeaves.SelectedValue);
        MasterEntries objMasterEntry = new MasterEntries();
        objMasterEntry.AddDuration(duration, leaveId);
        GridDuration();
    }

    public void GridDuration()
    {
        MasterEntries objMasterEntry = new MasterEntries();
        gvDuration.DataSource = objMasterEntry.GetAllDurations();
        gvDuration.DataBind();
    }

    protected void btnUpdateDuration_Click(object sender, EventArgs e)
    {
        int Id = Convert.ToInt32(Session["durationId"]);
        TimeSpan duration = TimeSpan.Parse(txtEditDuration.Text);
        MasterEntries objMasterEntries = new MasterEntries();
        objMasterEntries.UpdateDuration(Id, duration);
        GridDuration();
        popupEditDuration.Hide();
    }

    protected void lkbEditDuration_Click(object sender, EventArgs e)
    {
        MasterEntries objMasterEntry = new MasterEntries();
        LinkButton b = (LinkButton)sender;
        int Id = Convert.ToInt32(b.CommandArgument);
        TimeSpan editDuration = objMasterEntry.GetDurationById(Id);
        txtEditDuration.Text = editDuration.ToString();
        Session["durationId"] = Id;
        popupEditDuration.Show();
    }

    #endregion

    protected void btnEmployee_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/ViewEmployee.aspx");
    }

    protected void btnLeaveForEmployee_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/ViewEmployeeLeaves.aspx");
    }

    protected void btnReports_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/ReportMaster.aspx");
    }



    
}

