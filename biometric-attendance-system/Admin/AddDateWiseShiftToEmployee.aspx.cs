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

public partial class Admin_AddDateWiseShiftToEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropDown();
        }
       
    }

    public void BindDropDown()
    {
        ddlShift.Items.Clear();
        ddlShift.Items.Add("--Select--");
        MasterEntries objMasterEntries = new MasterEntries();
        ddlShift.DataSource = objMasterEntries.GetAllShifts();
        ddlShift.DataTextField = "Name";
        ddlShift.DataValueField = "Id";
        ddlShift.DataBind();
    }

    protected void btnAddSession_Click(object sender, EventArgs e)
    {
        int shiftId = Convert.ToInt32(ddlShift.SelectedValue);
        DateTime date = Calendar1.SelectedDate;
        int employeeId = Convert.ToInt32(txtEmployeeId.Text);
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        List<SqlParameter> lstparameter = new List<SqlParameter>();
        lstparameter.Add(new SqlParameter("@shiftId", shiftId));
        lstparameter.Add(new SqlParameter("@date", date));
        lstparameter.Add(new SqlParameter("@employeeId", employeeId));
        string query = "Insert into tblDateWiseShift values(@shiftId,@employeeId,@date)";
        DataTable dt = new DataTable();
        DataSet ds;
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            ds = objDDBDataHelper.GetDataSet(query, SQLTextType.Query, lstparameter);
        }
    }
}