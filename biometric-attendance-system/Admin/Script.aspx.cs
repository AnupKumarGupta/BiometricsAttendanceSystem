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

public partial class Admin_Script : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAddSession_Click(object sender, EventArgs e)
    {
        #region Add_Session
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;

        DateTime sessionStartDate = new DateTime(Int32.Parse(DateTime.Now.Year.ToString()), 8, 1);
        DateTime sessionEndDate = new DateTime(sessionStartDate.Year + 1, 7, 31);

        string query = "Select Count(*) from tblSession Where SessionStartDate=@sessionStartDate";
        List<SqlParameter> lstParams = new List<SqlParameter>();
        lstParams.Add(new SqlParameter("@sessionStartDate", sessionStartDate));
        DataTable ds = new DataTable();
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            ds = objDDBDataHelper.GetDataTable(query, SQLTextType.Query, lstParams);
        }

        if (ds.Rows.Count != 0)
            if (Int32.Parse(ds.Rows[0][0].ToString()) == 0)
            {

                string addSession = @"INSERT INTO [dbo].[tblSession]
                                      ([SessionStartDate]
                                       ,[SessionEndDate])
                                       VALUES (@sessionStartDate,@sessionEndDate)";

                List<SqlParameter> lstParams2 = new List<SqlParameter>();
                lstParams2.Add(new SqlParameter("@sessionStartDate", sessionStartDate));
                lstParams2.Add(new SqlParameter("@sessionEndDate", sessionEndDate));

                using (DBDataHelper objDDBDataHelper = new DBDataHelper())
                {
                    objDDBDataHelper.ExecSQL(addSession, SQLTextType.Query, lstParams2);
                }
                ManageReports objManageReprts = new ManageReports();
                objManageReprts.AssignSessionWiseLeave(sessionStartDate);
                objManageReprts.UpdateLeaveBalanceTable(sessionStartDate);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Session Added')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Session Exists')", true);
            }
        #endregion
    }
}