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

public partial class Admin_AddHoliday : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        lblDate.Text = Calendar1.SelectedDate.Date.ToString("d");
        txtHoliday.Text = "";
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
            if(dt != null && dt.Rows.Count>0)
            {
                btnAddHoliday.Enabled = false;
                btnAddHoliday.Text = "Holiday Exists";
                txtHoliday.Text = dt.Rows[0][0] == DBNull.Value ? "" : dt.Rows[0][0].ToString();
            }
        }
    }
    protected void btnAddHoliday_Click(object sender, EventArgs e)
    {
        string query = "INSERT INTO [tblHolidays] VALUES (@date,1,@nameOfHoliday)";
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DataTable dt = new DataTable();
        List<SqlParameter> lstData = new List<SqlParameter>();
        lstData.Add(new SqlParameter("@date", Calendar1.SelectedDate.Date.ToString("d")));
        lstData.Add(new SqlParameter("@nameOfHoliday", txtHoliday.Text));
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            objDDBDataHelper.ExecSQL(query, SQLTextType.Query, lstData);
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Holiday Added Successfully...');", true);
    }
}