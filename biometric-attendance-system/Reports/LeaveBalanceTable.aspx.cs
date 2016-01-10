using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_LeaveBalanceTable : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindDropDowns();
    }

    protected List<LeavesBalanceRecord> lstLeavesBalanceRecord = new List<LeavesBalanceRecord>();
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        txt_start_date.Text = Calendar1.SelectedDate.Date.ToString("d");
    }
    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        txt_end_date.Text = Calendar2.SelectedDate.Date.ToString("d");
    }
    protected void BindDropDowns()
    {
        MasterEntries objMasterEntries = new MasterEntries();
        ddlDepartments.DataSource = objMasterEntries.GetAllDepartments();
        ddlDepartments.DataTextField = "Name";
        ddlDepartments.DataValueField = "Id";
        ddlDepartments.DataBind();
    }

    protected void btnGetData_Click(object sender, EventArgs e)
    {
        ManageReports objManageReports = new ManageReports();
        lstLeavesBalanceRecord = objManageReports.GetDataForMonthlyLeaveBalanceTable(Convert.ToInt32(ddlDepartments.SelectedValue.ToString()), Calendar1.SelectedDate.Date, Calendar2.SelectedDate.Date);
        grid1.DataSource = lstLeavesBalanceRecord;
        grid1.DataBind();
    }
    public void grid1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int id = Convert.ToInt32(e.Row.Cells[0].Text);
            GridView grid2 = (GridView)e.Row.FindControl("grid2");
            GridView grid3 = (GridView)e.Row.FindControl("grid3");
            GridView grid4 = (GridView)e.Row.FindControl("grid4");
            GridView grid5 = (GridView)e.Row.FindControl("grid5");

            var y = lstLeavesBalanceRecord.Select(x => x).Where(d => d.EmployeeId == id).FirstOrDefault();
            grid2.DataSource = y.lstLeavesOldStack;
            grid2.DataBind();
            grid3.DataSource = y.lstLeavesDue;
            grid3.DataBind();
            grid4.DataSource = y.lstLeavesAvailed;
            grid4.DataBind();
            grid5.DataSource = y.lstLeavesBalance;
            grid5.DataBind();
        }
    }
}