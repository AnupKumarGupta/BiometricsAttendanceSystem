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

public partial class Admin_AddSession : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindData();
    }
    protected void BindData()
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DBDataHelper helper = new DBDataHelper();
        string query = @"SELECT [Id],[SessionStartDate],[SessionEndDate]
                         FROM [tblSession] ORDER BY [SessionStartDate] DESC";

        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            grdSession.DataSource = objDDBDataHelper.GetDataTable(query, SQLTextType.Query);
            grdSession.DataBind();
        }
    }

    protected void btnAddSession_Click(object sender, EventArgs e)
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DBDataHelper helper = new DBDataHelper();

        #region Get Last Session
        string query = @"SELECT TOP 1 [SessionStartDate],[SessionEndDate]
                         FROM  [tblSession]
                         ORDER BY [SessionStartDate] DESC";
        DataTable dt = new DataTable();
        DateTime startDate = new DateTime();
        DateTime endDate = new DateTime();
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            dt = objDDBDataHelper.GetDataTable(query, SQLTextType.Query);
            startDate = DateTime.Parse(dt.Rows[0][0].ToString());
            endDate = DateTime.Parse(dt.Rows[0][1].ToString());
        } 
        #endregion

        #region Adding New Session
        startDate = startDate.AddYears(1);
        endDate = endDate.AddYears(1);
        string query1 = @"INSERT INTO  [tblSession] 
                          VALUES (@startDate,@endDate)";
        List<SqlParameter> paramsLst = new List<SqlParameter>();
        paramsLst.Add(new SqlParameter("@startDate", startDate));
        paramsLst.Add(new SqlParameter("@endDate", endDate));
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            objDDBDataHelper.ExecSQL(query1, SQLTextType.Query, paramsLst);
        } 
        #endregion

        #region Update Leave Balance Table
        

        #endregion
    }
}