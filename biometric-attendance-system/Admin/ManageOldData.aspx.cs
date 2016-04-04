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

public partial class Admin_ManageOldData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindData();
    }
    protected void BindData()
    {
        ManageLeaves objManageLeaves = new ManageLeaves();
        grd_Employees.DataSource = objManageLeaves.getDataForOldLeaves(new DateTime(), new DateTime());
        grd_Employees.DataBind();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        List<SqlParameter> lstData = new List<SqlParameter>();
        lstData.Add(new SqlParameter("@employeeId", Convert.ToInt32(Session["id"])));
        lstData.Add(new SqlParameter("@sickleave", Convert.ToInt32(txtEditSL.Text)));
        lstData.Add(new SqlParameter("@emergencyLeave", Convert.ToInt32(txtEditEL.Text)));
        if (ddlDate.SelectedValue == "0")
        {
            lstData.Add(new SqlParameter("@sessionstart", new DateTime(2015, 08, 01)));
            lstData.Add(new SqlParameter("@sessionend", new DateTime(2016, 07, 31)));
        }
        else
        {
            lstData.Add(new SqlParameter("@sessionstart", new DateTime(2016, 08, 01)));
            lstData.Add(new SqlParameter("@sessionend", new DateTime(2017, 07, 31)));
        }
        string query = "Insert into tblLeavesOldStock values(@employeeId,@sickleave,@emergencyLeave,@sessionstart,@sessionend)";
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            objDDBDataHelper.ExecSQL(query, SQLTextType.Query, lstData);
        }
        BindData();
    }
    protected void lkbEditData_Click(object sender, EventArgs e)
    {
        LeavesOldStockViewModel objLeavesOldStockViewModel = new LeavesOldStockViewModel();
        popupEditData.Show();
        LinkButton b = (LinkButton)sender;
        lblName.Text = b.CommandArgument.Split(';')[1];
        Session["id"] = Convert.ToInt32(b.CommandArgument.Split(';')[0]);
        objLeavesOldStockViewModel = getDataForOldLeavesByEmployeeId(new DateTime(),new DateTime(), Convert.ToInt32(Session["id"]));
        txtEditEL.Text = objLeavesOldStockViewModel.elCount.ToString();
        txtEditSL.Text = objLeavesOldStockViewModel.slCount.ToString();
    }

    public LeavesOldStockViewModel getDataForOldLeavesByEmployeeId(DateTime sessionStartDate, DateTime sessionEndDate, int employeeId)
    {
        List<LeavesOldStockViewModel> lstLeavesOldStockViewModel = new List<LeavesOldStockViewModel>();
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DBDataHelper helper = new DBDataHelper();
        List<SqlParameter> lst_params = new List<SqlParameter>();
        lst_params.Add(new SqlParameter("@employeeId", employeeId));
        DataTable dt = new DataTable();
        string query = "SELECT tblEmployeesMaster.Id, Name ,[SLCount],[ELCount],[SessionStartDate],[SesssionEndDate] FROM[tblLeavesOldStock] right outer join tblEmployeesMaster On tblEmployeesMaster.Id = tblLeavesOldStock.EmployeeId Where tblLeavesOldStock.EmployeeId = @employeeId";
        LeavesOldStockViewModel objLeavesOldStockViewModel = new LeavesOldStockViewModel();
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            dt = objDDBDataHelper.GetDataTable(query, SQLTextType.Query, lst_params);
            foreach (DataRow row in dt.Rows)
            {
                objLeavesOldStockViewModel.employeeId = row[0] == DBNull.Value ? 0 : Int32.Parse(row[0].ToString());
                objLeavesOldStockViewModel.employeeName = row[1] == DBNull.Value ? "" : row[1].ToString();
                objLeavesOldStockViewModel.slCount = row[2] == DBNull.Value ? 0 : Int32.Parse(row[2].ToString());
                objLeavesOldStockViewModel.elCount = row[3] == DBNull.Value ? 0 : Int32.Parse(row[3].ToString());
                objLeavesOldStockViewModel.sessionStartDate = row[4] == DBNull.Value ? DateTime.Now : DateTime.Parse(row[4].ToString());
                objLeavesOldStockViewModel.sessionEndDate = row[5] == DBNull.Value ? DateTime.Now : DateTime.Parse(row[5].ToString());
                
            }
        }

        return objLeavesOldStockViewModel;
    }
}