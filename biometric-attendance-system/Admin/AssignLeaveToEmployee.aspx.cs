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

public partial class Admin_AssignLeaveToEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["employeeId"] == null)
        { Response.Redirect("~/Admin/AssignLeave.aspx"); }
        if (!IsPostBack)
            BindDropdown();
        if (Session["employeeId"] != null)
            lblName.Text = Session["employeeName"].ToString();
    }

    protected void Calender1_SelectionChanged(object sender, EventArgs e)
    {
        txt_date.Text = Calendar1.SelectedDate.Date.ToString("d");
        BindGrid();
    }
    public List<AssignLeaveViewModel> BindGridData()
    {
        MasterEntries objMasterEntries = new MasterEntries();
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DataTable dt = new DataTable();
        List<SqlParameter> lstData = new List<SqlParameter>();
        lstData.Add(new SqlParameter("@employeeId", Convert.ToInt32(Session["employeeId"])));
        lstData.Add(new SqlParameter("@date", Calendar1.SelectedDate.Date));
        DataSet ds;
        string query = "Select LeaveTypeId from tblLeave where EmployeeId=@employeeId And Date=@date";
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            ds = objDDBDataHelper.GetDataSet(query, SQLTextType.Query, lstData);
            List<AssignLeaveViewModel> lstLeaves = new List<AssignLeaveViewModel>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                AssignLeaveViewModel objLeaves = new AssignLeaveViewModel();
                int leaveId = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                Leaves objLeaves1 = new Leaves();
                objMasterEntries.GetLeavesById(leaveId, out objLeaves1);
                objLeaves.Id = objLeaves1.Id;
                objLeaves.LeaveName = objLeaves1.LeaveName;
                objLeaves.EmployeeId = Convert.ToInt32(Session["employeeId"]);
                objLeaves.Date = Calendar1.SelectedDate.Date;
                lstLeaves.Add(objLeaves);
            }
            return lstLeaves;
        }
    }
    public void BindGrid()
    {
        btnAssignLeave.Enabled = true;
        gvViewEmployeeOnLeaveForDate.DataSource = BindGridData();
        gvViewEmployeeOnLeaveForDate.DataBind();
        if (gvViewEmployeeOnLeaveForDate.Rows.Count > 0)
        {
            btnAssignLeave.Enabled = false;
            btnAssignLeave.Text = "Employee On Leave";
        }
    }
    protected void btnAssignLeave_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(ddlLeaves.SelectedValue) > 0)
        {
            DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
            DataTable dt = new DataTable();
            List<SqlParameter> lstData = new List<SqlParameter>();
            lstData.Add(new SqlParameter("@employeeId", Convert.ToInt32(Session["employeeId"])));
            lstData.Add(new SqlParameter("@date", Calendar1.SelectedDate.Date));
            lstData.Add(new SqlParameter("@leaveTypeId", Convert.ToInt32(ddlLeaves.SelectedValue)));
            lstData.Add(new SqlParameter("@createdAt", DateTime.Now));
            DataSet ds;
            using (DBDataHelper objDDBDataHelper = new DBDataHelper())
            {
                objDDBDataHelper.ExecSQL("spAssignLeave", SQLTextType.Stored_Proc, lstData);
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Leave Assigned');", true);
            BindGrid();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Select a Leave');", true);
        }
    }
    public void BindDropdown()
    {
        MasterEntries objMasterEntries = new MasterEntries();
        ddlLeaves.DataSource = objMasterEntries.GetAllTypeOfLeaves();
        ddlLeaves.DataTextField = "LeaveName";
        ddlLeaves.DataValueField = "Id";
        ddlLeaves.DataBind();
    }
}