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
        Calendar1.SelectedDates.Clear();
        BindGrid();
        if (Session["employeeId"] == null)
        {
            Response.Redirect("~/Admin/AssignLeave.aspx");
        }
        if (!IsPostBack)
            BindDropdown();
        if (Session["employeeId"] != null)
            lblName.Text = Session["employeeName"].ToString();
    }

    public static List<DateTime> list = new List<DateTime>();
    public List<AssignLeaveViewModel> GetDataForGridview()
    {
        MasterEntries objMasterEntries = new MasterEntries();
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DateTime sessionStartDate = new DateTime();
        DateTime sessionEndDate = new DateTime();
        if (DateTime.Now.Month <= 7)
        {
            sessionStartDate = new DateTime(DateTime.Now.Year - 1, 8, 1);
            sessionEndDate = new DateTime(DateTime.Now.Year, 7, 31);
        }
        else
        {
            sessionStartDate = new DateTime(DateTime.Now.Year, 8, 1);
            sessionEndDate = new DateTime(DateTime.Now.Year + 1, 7, 31);
        }

        List<SqlParameter> lstData = new List<SqlParameter>();
        lstData.Add(new SqlParameter("@employeeId", Convert.ToInt32(Session["employeeId"])));
        lstData.Add(new SqlParameter("@sessionStartDate", sessionStartDate));
        lstData.Add(new SqlParameter("@sessionEndDate", sessionEndDate));
        lstData.Add(new SqlParameter("@IsDeleted", Convert.ToInt32(0)));

        DataSet ds;
        int i = 0;
        string query = @"SELECT Id , LeaveTypeId , [Date] 
                         FROM tblLeave 
                         WHERE [Date]  >= @sessionStartDate
                         AND [Date] <= @sessionEndDate 
                         AND EmployeeId = @employeeId 
                         AND IsDeleted = @IsDeleted";

        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            ds = objDDBDataHelper.GetDataSet(query, SQLTextType.Query, lstData);
            List<AssignLeaveViewModel> lstLeaves = new List<AssignLeaveViewModel>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                AssignLeaveViewModel objLeaves = new AssignLeaveViewModel();
                int Id = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
                int leaveId = Convert.ToInt32(ds.Tables[0].Rows[i][1]);
                Leaves objLeaves1 = new Leaves();
                objMasterEntries.GetLeavesById(leaveId, out objLeaves1);
                objLeaves.leaveId = Id;
                objLeaves.Id = objLeaves1.Id;
                objLeaves.LeaveName = objLeaves1.LeaveName;
                objLeaves.EmployeeId = Convert.ToInt32(Session["employeeId"]);
                objLeaves.Date = (Convert.ToDateTime(ds.Tables[0].Rows[i][2])).Date;
                lstLeaves.Add(objLeaves);
                i++;
            }
            return lstLeaves;
        }
    }
    public void BindGrid()
    {
        var x = GetDataForGridview();
        gvViewEmployeeOnLeaveForDate.DataSource = x;
        gvViewEmployeeOnLeaveForDate.DataBind();

        //foreach (var date in x)
        //{
        //    btnAssignLeave.Text = "Assign Leave";
        //    DateTime Date = date.Date;
        //    if (Date >= Calendar1.SelectedDate.Date && Date <= Calendar2.SelectedDate.Date)
        //    {
        //        btnAssignLeave.Enabled = false;
        //        btnAssignLeave.Text = "Employee On Leave";
        //    }
        //}
    }
    public void AssignLeave(DateTime date)
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DataTable dt = new DataTable();
        List<SqlParameter> lstData = new List<SqlParameter>();
        lstData.Add(new SqlParameter("@employeeId", Convert.ToInt32(Session["employeeId"])));
        lstData.Add(new SqlParameter("@date", date));
        lstData.Add(new SqlParameter("@leaveTypeId", Convert.ToInt32(ddlLeaves.SelectedValue)));
        lstData.Add(new SqlParameter("@createdAt", DateTime.Now));
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            objDDBDataHelper.ExecSQL("spAssignLeave", SQLTextType.Stored_Proc, lstData);
        }
    }
    protected void btnAssignLeave_Click(object sender, EventArgs e)
    {
        List<DateTime> newList = new List<DateTime>();
        if (Session["SelectedDates"] != null)
            newList = (List<DateTime>)Session["SelectedDates"];

        if (Convert.ToInt32(ddlLeaves.SelectedValue) > 0)
        {
            foreach (var date in newList)
            {
                AssignLeave(date);
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Leave Assigned');", true);
            BindGrid();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Select a Leave');", true);
        }
        Calendar1.SelectedDates.Clear();
    }
    public void BindDropdown()
    {
        MasterEntries objMasterEntries = new MasterEntries();
        ddlLeaves.DataSource = objMasterEntries.GetAllTypeOfLeaves();
        ddlLeaves.DataTextField = "LeaveName";
        ddlLeaves.DataValueField = "Id";
        ddlLeaves.DataBind();
    }
    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        LinkButton b = (LinkButton)sender;
        int id = Convert.ToInt32(b.CommandArgument);
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DataTable dt = new DataTable();
        List<SqlParameter> lstData = new List<SqlParameter>();
        lstData.Add(new SqlParameter("@leaveId", id));
        DataSet ds;
        int i = 0;
        string query = "Update tblLeave set IsDeleted = 1 where Id = @leaveId";
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            ds = objDDBDataHelper.GetDataSet(query, SQLTextType.Query, lstData);
        }
    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.IsSelected == true)
        {
            list.Add(e.Day.Date);
        }
        Session["SelectedDates"] = list;
    }
    protected void Calender1_SelectionChanged(object sender, EventArgs e)
    {
        if (Session["SelectedDates"] != null)
        {
            List<DateTime> newList = (List<DateTime>)Session["SelectedDates"];
            int count = 0;
            foreach (DateTime dt in newList)
            {
                Calendar1.SelectedDates.Add(dt);
                count = LeaveExists(dt);
            }
            if (count > 0)
            {
                btnAssignLeave.Enabled = false;
                btnAssignLeave.Text = "Employee On Leave";
            }
            list.Clear();
        }
    }
    protected int LeaveExists(DateTime date)
    {
        MasterEntries objMasterEntries = new MasterEntries();
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;

        List<SqlParameter> lstData = new List<SqlParameter>();
        lstData.Add(new SqlParameter("@employeeId", Convert.ToInt32(Session["employeeId"])));
        lstData.Add(new SqlParameter("@date", date));
        lstData.Add(new SqlParameter("@IsDeleted", Convert.ToInt32(0)));

        DataSet ds;
        string query = @"SELECT Count(Id) 
                         FROM tblLeave 
                         WHERE [Date] = @date
                         AND EmployeeId = @employeeId 
                         AND IsDeleted = @IsDeleted";

        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            ds = objDDBDataHelper.GetDataSet(query, SQLTextType.Query, lstData);
            List<AssignLeaveViewModel> lstLeaves = new List<AssignLeaveViewModel>();
            int number = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            return number;
        }
    }
}