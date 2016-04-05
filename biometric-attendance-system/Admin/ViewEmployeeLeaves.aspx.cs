using DALHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
        Session["empId"] = Id;
        var y = lstLeaveAssignedRecord.Select(x => x).Where(d => d.EmployeeId == Id).FirstOrDefault();
        EditgvLeaves.DataSource = y.lstAssignedRecord;
        EditgvLeaves.DataBind();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        List<LeaveAssignedRecord> lstLeaveAssignedRecord = new List<LeaveAssignedRecord>();
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DataSet ds;
        int leaveId;
        LeaveAssignedPerSession objLeaveAssignedPerSession = new LeaveAssignedPerSession();
        ManageReports objManageReports = new ManageReports();
        foreach (RepeaterItem i in EditgvLeaves.Items)
        {
            TextBox txtLeaveCount = (TextBox)i.FindControl("txtLeaveCount");
            Label txtLeaveName = (Label)i.FindControl("txtLeave");
            string leaveName = txtLeaveName.Text;
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@name", leaveName));
            string query = "Select Id from tblTypeOfLeave where Name = @name";
            using (DBDataHelper objDDBDataHelper = new DBDataHelper())
            {
                ds = objDDBDataHelper.GetDataSet(query, SQLTextType.Query, lstParams);
                leaveId = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            }

            DateTime SessionStartDate, SessionEndDate;
            if (DateTime.Now.Month >= 8)
            {
                SessionStartDate = new DateTime(DateTime.Now.Year, 08, 01);
                SessionEndDate = new DateTime(DateTime.Now.Year+1, 07, 31);
            }
            else
            {
                SessionStartDate = new DateTime(DateTime.Now.Year-1, 08, 01);
                SessionEndDate = new DateTime(DateTime.Now.Year, 07, 31);
            }
            objLeaveAssignedPerSession.EmployeeId = Convert.ToInt32(Session["empId"]);
            objLeaveAssignedPerSession.leaveCount = Convert.ToInt32(txtLeaveCount.Text);
            objLeaveAssignedPerSession.leaveType = leaveId;
            objManageReports.UpdateLeavesAssignedPerSessionEmployeeWise(objLeaveAssignedPerSession, SessionStartDate,SessionEndDate);
        }

        popupEditLeaveAssigned.Hide();
    }
}