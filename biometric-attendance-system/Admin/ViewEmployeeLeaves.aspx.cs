using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ViewEmployeeLeaves : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindDropDowns();
    }
    protected void BindDropDowns()
    {
        MasterEntries objMasterEntries = new MasterEntries();
        ddlShowDepartment.DataSource = objMasterEntries.GetAllDepartments();
        ddlShowDepartment.DataTextField = "Name";
        ddlShowDepartment.DataValueField = "Id";
        ddlShowDepartment.DataBind();
    }

    protected List<LeaveAssignedRecord> lstLeaveAssignedRecord = new List<LeaveAssignedRecord>();
    protected void ddlShowDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        int departmentId = Convert.ToInt32(ddlShowDepartment.SelectedValue);
        ManageReports objManageReports = new ManageReports();
        lstLeaveAssignedRecord = objManageReports.GetLeavesAssignedPerSession(departmentId, DateTime.Now);
        grid1.DataSource = lstLeaveAssignedRecord;
        grid1.DataBind();

    }
    public void grid1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int id = Convert.ToInt32(e.Row.Cells[0].Text);
            GridView grid2 = (GridView)e.Row.FindControl("grid2");
            var y = lstLeaveAssignedRecord.Select(x => x).Where(d => d.EmployeeId == id).FirstOrDefault();
            grid2.DataSource = y.lstAssignedRecord;
            grid2.DataBind();
        }
    }


    protected void lkbEditLeaveAssinged_Click(object sender, EventArgs e)
    {
        popupEditLeaveAssigned.Show();
        LinkButton b = (LinkButton)sender;
        int departmentId = Convert.ToInt32(ddlShowDepartment.SelectedValue);
        ManageReports objManageReports = new ManageReports();
        lstLeaveAssignedRecord = objManageReports.GetLeavesAssignedPerSession(departmentId, DateTime.Now);
        int Id = Convert.ToInt32(b.CommandArgument);
        var y = lstLeaveAssignedRecord.Select(x => x).Where(d => d.EmployeeId == Id).FirstOrDefault();
        EditgvLeaves.DataSource = y.lstAssignedRecord;
        EditgvLeaves.DataBind();
    }
}