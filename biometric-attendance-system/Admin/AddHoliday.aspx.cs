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
using BAS.Enums;

public partial class Admin_AddHoliday : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Calendar1.SelectedDate = DateTime.Now;
        BindData();
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        BindData();
        lblDate.Text = Calendar1.SelectedDate.Date.ToString("d");
        txtHoliday.Text = "";
        btnAddHoliday.Text = "Add Holiday";
        btnAddHoliday.Enabled = true;

        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DBDataHelper helper = new DBDataHelper();
        string query = @"SELECT [NameOfHoliday]
                         FROM [tblHolidays]
                         WHERE Date = @date";
        List<SqlParameter> lst_params = new List<SqlParameter>();
        lst_params.Add(new SqlParameter("@date", Calendar1.SelectedDate));
        DataTable dt = new DataTable();
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            dt = objDDBDataHelper.GetDataTable(query, SQLTextType.Query, lst_params);
            if (dt != null && dt.Rows.Count > 0)
            {
                btnAddHoliday.Enabled = false;
                btnAddHoliday.Text = "Holiday Exists";
                txtHoliday.Text = dt.Rows[0][0] == DBNull.Value ? "" : dt.Rows[0][0].ToString();
            }
        }
    }
    protected void btnAddHoliday_Click(object sender, EventArgs e)
    {
        string query = "INSERT INTO [tblHolidays] VALUES (@date,@status,@nameOfHoliday)";
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DataTable dt = new DataTable();
        List<SqlParameter> lstData = new List<SqlParameter>();
        lstData.Add(new SqlParameter("@date", Calendar1.SelectedDate.Date.ToString("d")));
        lstData.Add(new SqlParameter("@nameOfHoliday", txtHoliday.Text == "" ? ((Convert.ToInt32(ddlStatus.SelectedValue)) == (int)DayStatus.Holiday ? DayStatus.Holiday.ToString() : "Weekly Off") : (txtHoliday.Text)));
        lstData.Add(new SqlParameter("@status", ddlStatus.SelectedValue));
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            objDDBDataHelper.ExecSQL(query, SQLTextType.Query, lstData);
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Holiday Added Successfully...');", true);
        btnAddHoliday.Enabled = false;
        btnAddHoliday.Text = "Holiday Exists";
        txtHoliday.Text = dt.Rows[0][0] == DBNull.Value ? "" : dt.Rows[0][0].ToString();
        BindData();
    }
    protected void BindData()
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DBDataHelper helper = new DBDataHelper();
        string query = @"SELECT [Id],[NameOfHoliday],[Status],[Date]
                             FROM [tblHolidays]
                             WHERE year([Date]) = year(@date)";

        List<SqlParameter> lst_params = new List<SqlParameter>();
        lst_params.Add(new SqlParameter("@date", Calendar1.SelectedDate));

        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            grdHoliday.DataSource = objDDBDataHelper.GetDataTable(query, SQLTextType.Query, lst_params);
            grdHoliday.DataBind();
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        int id = Convert.ToInt32(btn.CommandArgument);
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DataTable dt = new DataTable();
        List<SqlParameter> lstData = new List<SqlParameter>();
        lstData.Add(new SqlParameter("@id", id));
        DataSet ds;
        string query = "DELETE FROM tblHolidays WHERE Id=@id";
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
          objDDBDataHelper.ExecSQL(query, SQLTextType.Query, lstData);
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Holiday Deleted Successfully...');", true);
        BindData();
    }
}