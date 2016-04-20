using DALHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BAS.Enums;

public class ManageLeaves
{
    #region Very Old Code
    public List<TypeOfLeave> LeaveFromGivenMasterLeaveType(int masterLeaveType)
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DBDataHelper helper = new DBDataHelper();
        List<SqlParameter> lstLeaveDetail = new List<SqlParameter>();
        string query = "select Id,Name from tblTypeOfLeave where MasterLeaveType=@masterleavetype";
        lstLeaveDetail.Add(new SqlParameter("@masterleavetype", masterLeaveType));
        DataTable dt = new DataTable();
        DataSet ds;
        int i = 0;
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            ds = objDDBDataHelper.GetDataSet(query, SQLTextType.Query, lstLeaveDetail);
            List<TypeOfLeave> lstLeaveType = new List<TypeOfLeave>();
            foreach (DataRow rows in ds.Tables[0].Rows)
            {
                TypeOfLeave objLeaveType = new TypeOfLeave();
                objLeaveType.Id = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
                objLeaveType.Name = (ds.Tables[0].Rows[i][1]).ToString();
                lstLeaveType.Add(objLeaveType);
                i++;
            }
            return lstLeaveType;
        }

    }
    public bool IsLeaveExist(int employeeId, DateTime date)
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DBDataHelper helper = new DBDataHelper();
        List<SqlParameter> lstLeaveDetail = new List<SqlParameter>();
        lstLeaveDetail.Add(new SqlParameter("@employeeId", employeeId));
        lstLeaveDetail.Add(new SqlParameter("@date", date));

        List<SqlParameter> lstLeaveDetail1 = new List<SqlParameter>();
        lstLeaveDetail1.Add(new SqlParameter("@employeeId", employeeId));
        lstLeaveDetail1.Add(new SqlParameter("@date", date));

        List<SqlParameter> lstLeaveDetail2 = new List<SqlParameter>();
        lstLeaveDetail2.Add(new SqlParameter("@employeeId", employeeId));
        lstLeaveDetail2.Add(new SqlParameter("@date", date));

        List<SqlParameter> lstLeaveDetail3 = new List<SqlParameter>();
        lstLeaveDetail3.Add(new SqlParameter("@employeeId", employeeId));
        lstLeaveDetail3.Add(new SqlParameter("@date", date));

        DataTable dt = new DataTable();
        DataSet ds, ds1, ds2, ds3;
        // string query = "insert into tblLeave values(@employeeId,@leaveTypeId,@createdOn,@updatedOn,@isDeleted)";
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            //  ds = objDDBDataHelper.GetDataSet("IsEmployeeOnMultidayLeaveByDate", SQLTextType.Stored_Proc, lstLeaveDetail);
            ds1 = objDDBDataHelper.GetDataSet("spIsEmployeeOnHalfDayLeaveByDate", SQLTextType.Stored_Proc, lstLeaveDetail1);
            ds2 = objDDBDataHelper.GetDataSet("spIsEmployeeOnFullDayLeaveByDate", SQLTextType.Stored_Proc, lstLeaveDetail2);
            ds3 = objDDBDataHelper.GetDataSet("spIsEmployeeOnDurationalLeaveByDate", SQLTextType.Stored_Proc, lstLeaveDetail3);
        }
        int count = Convert.ToInt32(ds1.Tables[0].Rows[0][0]);
        int count1 = Convert.ToInt32(ds1.Tables[0].Rows[0][0]);
        int count2 = Convert.ToInt32(ds2.Tables[0].Rows[0][0]);
        int count3 = Convert.ToInt32(ds3.Tables[0].Rows[0][0]);
        if (count == 1 || count1 == 1 || count2 >= 1 || count3 == 1)
            return false;
        else
            return true;
    }
    public bool FullDayLeave(int employeeId, DateTime date, int leaveTypeId)
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DBDataHelper helper = new DBDataHelper();
        List<SqlParameter> lstFullDayLeave = new List<SqlParameter>();
        lstFullDayLeave.Add(new SqlParameter("@employeeId", employeeId));
        lstFullDayLeave.Add(new SqlParameter("@leaveTypeId", leaveTypeId));
        lstFullDayLeave.Add(new SqlParameter("@createdAt", DateTime.Now));
        lstFullDayLeave.Add(new SqlParameter("@updatedAt", DateTime.Now));
        lstFullDayLeave.Add(new SqlParameter("@date", date));
        DataTable dt = new DataTable();
        try
        {
            using (DBDataHelper objDDBDataHelper = new DBDataHelper())
            {
                objDDBDataHelper.ExecSQL("spAssignFullDayLeave", SQLTextType.Stored_Proc, lstFullDayLeave);
            }
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    public bool DurationalLeave(int employeeId, int leaveId, DateTime date)
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DBDataHelper helper = new DBDataHelper();
        string query = "select Id from tblDuration where IsActive=1";
        DataSet ds;
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            ds = objDDBDataHelper.GetDataSet(query, SQLTextType.Query);
        }
        int durationId = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        List<SqlParameter> lstDurationalLeave = new List<SqlParameter>();
        lstDurationalLeave.Add(new SqlParameter("@employeeId", employeeId));
        lstDurationalLeave.Add(new SqlParameter("@leaveTypeId", leaveId));
        lstDurationalLeave.Add(new SqlParameter("@date", date));
        lstDurationalLeave.Add(new SqlParameter("@DurationalId", durationId));
        lstDurationalLeave.Add(new SqlParameter("@createdAt", DateTime.Now));
        lstDurationalLeave.Add(new SqlParameter("@updatedAt", DateTime.Now));
        DataTable dt = new DataTable();
        try
        {
            using (DBDataHelper objDDBDataHelper = new DBDataHelper())
            {
                objDDBDataHelper.ExecSQL("spAssignDurationalLeave", SQLTextType.Stored_Proc, lstDurationalLeave);
            }
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    public bool HalfDayLeave(int employeeId, DateTime date, int leaveId)
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DBDataHelper helper = new DBDataHelper();
        string query = "select Id from tblShifts where IsActive=1";
        DataSet ds;
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            ds = objDDBDataHelper.GetDataSet(query, SQLTextType.Query);
        }
        int shiftId = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        List<SqlParameter> lstHalfDayLeave = new List<SqlParameter>();
        lstHalfDayLeave.Add(new SqlParameter("@employeeId", employeeId));
        lstHalfDayLeave.Add(new SqlParameter("@leaveTypeId", leaveId));
        lstHalfDayLeave.Add(new SqlParameter("@date", date));
        lstHalfDayLeave.Add(new SqlParameter("@shiftId", shiftId));
        lstHalfDayLeave.Add(new SqlParameter("@shift", 1));
        lstHalfDayLeave.Add(new SqlParameter("@createdAt", DateTime.Now));
        lstHalfDayLeave.Add(new SqlParameter("@updatedAt", DateTime.Now));
        DataTable dt = new DataTable();
        try
        {
            using (DBDataHelper objDDBDataHelper = new DBDataHelper())
            {
                objDDBDataHelper.ExecSQL("spAssignHalfDayLeave", SQLTextType.Stored_Proc, lstHalfDayLeave);
            }
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    public bool MultiDayLeave(int employeeId, int leaveId, DateTime StartDate, DateTime EndDate)
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DBDataHelper helper = new DBDataHelper();
        List<SqlParameter> lstMultiDayLeave = new List<SqlParameter>();
        lstMultiDayLeave.Add(new SqlParameter("@employeeId", employeeId));
        lstMultiDayLeave.Add(new SqlParameter("@leaveTypeId", leaveId));
        lstMultiDayLeave.Add(new SqlParameter("@startDate", StartDate));
        lstMultiDayLeave.Add(new SqlParameter("@endDate", EndDate));
        lstMultiDayLeave.Add(new SqlParameter("@createdAt", DateTime.Now));
        lstMultiDayLeave.Add(new SqlParameter("@updatedAt", DateTime.Now));
        DataTable dt = new DataTable();
        try
        {
            using (DBDataHelper objDDBDataHelper = new DBDataHelper())
            {
                objDDBDataHelper.ExecSQL("spAssignMultiDayLeaveLeave", SQLTextType.Stored_Proc, lstMultiDayLeave);
            }
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    #endregion

    #region Old Code
    public bool IsEmployeeOnLeave(int employeeId, DateTime date, out string LeaveType)
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DBDataHelper helper = new DBDataHelper();
        List<SqlParameter> lstLeave1 = new List<SqlParameter>();
        lstLeave1.Add(new SqlParameter("@employeeId", employeeId));
        lstLeave1.Add(new SqlParameter("@date", date));
        List<SqlParameter> lstLeave2 = new List<SqlParameter>();
        lstLeave2.Add(new SqlParameter("@employeeId", employeeId));
        lstLeave2.Add(new SqlParameter("@date", date));
        List<SqlParameter> lstLeave3 = new List<SqlParameter>();
        lstLeave3.Add(new SqlParameter("@employeeId", employeeId));
        lstLeave3.Add(new SqlParameter("@date", date));
        List<SqlParameter> lstLeave4 = new List<SqlParameter>();
        lstLeave4.Add(new SqlParameter("@employeeId", employeeId));
        lstLeave4.Add(new SqlParameter("@date", date));
        List<SqlParameter> lstLeave5 = new List<SqlParameter>();
        lstLeave5.Add(new SqlParameter("@employeeId", employeeId));
        lstLeave5.Add(new SqlParameter("@date", date));

        DataSet ds1, ds2, ds3, ds4, ds5 = new DataSet();
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            ds1 = objDDBDataHelper.GetDataSet("spIsEmployeeOnMultidayLeaveByDate", SQLTextType.Stored_Proc, lstLeave1);
            ds2 = objDDBDataHelper.GetDataSet("spIsEmployeeOnHalfDayLeaveByDate", SQLTextType.Stored_Proc, lstLeave2);
            ds3 = objDDBDataHelper.GetDataSet("spIsEmployeeOnFullDayLeaveByDate", SQLTextType.Stored_Proc, lstLeave3);
            ds4 = objDDBDataHelper.GetDataSet("spIsEmployeeOnDurationalLeaveByDate", SQLTextType.Stored_Proc, lstLeave4);
        }
        int count1 = ds1.Tables.Count > 0 ? (ds1.Tables[0].Rows.Count > 0 ? Convert.ToInt32(ds1.Tables[0].Rows[0][0]) : 0) : 0;
        int count2 = ds2.Tables.Count > 0 ? (ds2.Tables[0].Rows.Count > 0 ? Convert.ToInt32(ds2.Tables[0].Rows[0][0]) : 0) : 0;
        int count3 = ds3.Tables.Count > 0 ? (ds3.Tables[0].Rows.Count > 0 ? Convert.ToInt32(ds3.Tables[0].Rows[0][0]) : 0) : 0;
        int count4 = ds4.Tables.Count > 0 ? (ds4.Tables[0].Rows.Count > 0 ? Convert.ToInt32(ds4.Tables[0].Rows[0][0]) : 0) : 0;


        if (count1 > 0 || count2 > 0 || count3 > 0 || count4 > 0)
        {
            using (DBDataHelper objDDBDataHelper = new DBDataHelper())
            {
                ds5 = objDDBDataHelper.GetDataSet("spGetTypeOfLeaveOfEmployeeByDate", SQLTextType.Stored_Proc, lstLeave5);
            }
            LeaveType = ds5.Tables[0].Rows[0][0].ToString();
            return true;
        }
        else
        {
            LeaveType = "No Leave";
            return false;
        }
    }

    #endregion

    #region New Code
    public bool IsEmployeeOnLeave(int employeeId, DateTime date, out int LeaveType)
    {
        List<SqlParameter> list_params = new List<SqlParameter>() { new SqlParameter("@date", date), new SqlParameter("@employeeId", employeeId) };
        DataTable dt;
        int count = 0;

        using (DBDataHelper helper = new DBDataHelper())
        {
            dt = helper.GetDataTable("spGetTypeOfLeaveOfEmployeeByDate", SQLTextType.Stored_Proc, list_params);
            foreach (DataRow row in dt.Rows)
            {
                count = int.Parse(row[0].ToString());
                break;
            }
        }

        if (count == 0)
        {
            LeaveType = 0;
            return false;
        }
        else
        {
            LeaveType = count;
            return false;
        }
    }
    public TimeSpan GetShortLeaveDuration()
    {
        DataTable dt;
        TimeSpan dr = new TimeSpan();
        string query = "Select Duration From tblDuration Where IsActive= 1 AND IsDeleted = 0 AND TypeOfLeave = 1";
        try
        {
            using (DBDataHelper helper = new DBDataHelper())
            {
                dt = helper.GetDataTable(query, SQLTextType.Query);
                dr = dt.Rows[0][0] == DBNull.Value ? new TimeSpan(0, 0, 0) : TimeSpan.Parse(dt.Rows[0][0].ToString());
            }
        }
        catch (Exception)
        {
            dr = new TimeSpan(0, 0, 0);
        }
        return dr;
    }
    public TimeSpan GetHalfDayLeaveDuration()
    {
        DataTable dt;
        TimeSpan dr = new TimeSpan();
        string query = "Select Duration From tblDuration Where IsActive= 1 AND IsDeleted = 0 AND TypeOfLeave = 2";
        try
        {
            using (DBDataHelper helper = new DBDataHelper())
            {
                dt = helper.GetDataTable(query, SQLTextType.Query);
                dr = dt.Rows[0][0] == DBNull.Value ? new TimeSpan(0, 0, 0) : TimeSpan.Parse(dt.Rows[0][0].ToString());

            }
        }
        catch (Exception)
        {
            new TimeSpan(0, 0, 0);
        }
        return dr;
    }
    public bool AssignLeave(int employeeId, DateTime date, int leaveTypeId)
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DBDataHelper helper = new DBDataHelper();
        List<SqlParameter> lst_params = new List<SqlParameter>();
        lst_params.Add(new SqlParameter("@date", date));
        lst_params.Add(new SqlParameter("@employeeId", employeeId));

        string query = "SELECT Count([EmployeeId]) FROM  [tblLeave] Where [Date] = @date AND [EmployeeId] =@employeeId AND [isDeleted]=0";
        DataTable dt = new DataTable();

        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            dt = objDDBDataHelper.GetDataTable(query, SQLTextType.Query, lst_params);
        }

        if (Int32.Parse(dt.Rows[0][0].ToString()) == 0)
        {
            return false;
        }
        else
        {
            List<SqlParameter> lst_params1 = new List<SqlParameter>();
            lst_params1.Add(new SqlParameter("@employeeId", employeeId));
            lst_params1.Add(new SqlParameter("@date", date));
            lst_params1.Add(new SqlParameter("@leaveTypeId", leaveTypeId));
            lst_params1.Add(new SqlParameter("@createdAt", DateTime.Now));

            try
            {
                using (DBDataHelper objDDBDataHelper = new DBDataHelper())
                {
                    objDDBDataHelper.ExecSQL("spAssignLeave", SQLTextType.Stored_Proc, lst_params1);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
    public bool AssignHalfDayLeaveRemovingShortDayLeave(int employeeId, DateTime date)
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DBDataHelper helper = new DBDataHelper();
        List<SqlParameter> lst_params = new List<SqlParameter>();
        lst_params.Add(new SqlParameter("@employeeId", employeeId));
        lst_params.Add(new SqlParameter("@date", date));
        string query = "SELECT Count([EmployeeId]) FROM  [tblLeave] Where [Date] = @date AND [EmployeeId] =@employeeId AND isDeleted=0";
        DataTable dt = new DataTable();

        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            dt = objDDBDataHelper.GetDataTable(query, SQLTextType.Query, lst_params);
        }
        if (Int32.Parse(dt.Rows[0][0].ToString()) == 0)
        {
            AssignLeave(employeeId, date, (int)LeaveTypes.HDL);
            return true;
        }
        else
        {
            List<SqlParameter> lst_params1 = new List<SqlParameter>();
            lst_params1.Add(new SqlParameter("@employeeId", employeeId));
            lst_params1.Add(new SqlParameter("@date", date));
            lst_params1.Add(new SqlParameter("@createdAt", DateTime.Now));

            try
            {
                using (DBDataHelper objDDBDataHelper = new DBDataHelper())
                {
                    objDDBDataHelper.ExecSQL("spAssignHalfDayLeaveRemovingShortDayLeave", SQLTextType.Stored_Proc, lst_params1);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
    public List<LeavesOldStockViewModel> getDataForOldLeaves(DateTime sessionStartDate, DateTime sessionEndDate)
    {
        List<LeavesOldStockViewModel> lstLeavesOldStockViewModel = new List<LeavesOldStockViewModel>();
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DBDataHelper helper = new DBDataHelper();
        List<SqlParameter> lst_params = new List<SqlParameter>();
        DataTable dt = new DataTable();
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            dt = objDDBDataHelper.GetDataTable("spGetDataForOldLeaves", SQLTextType.Query, lst_params);
            foreach (DataRow row in dt.Rows)
            {
                LeavesOldStockViewModel objLeavesOldStockViewModel = new LeavesOldStockViewModel();
                objLeavesOldStockViewModel.employeeId = row[0] == DBNull.Value ? 0 : Int32.Parse(row[0].ToString());
                objLeavesOldStockViewModel.employeeName = row[1] == DBNull.Value ? "" : row[1].ToString();
                objLeavesOldStockViewModel.slCount = row[2] == DBNull.Value ? 0 : Int32.Parse(row[2].ToString());
                objLeavesOldStockViewModel.elCount = row[3] == DBNull.Value ? 0 : Int32.Parse(row[3].ToString());
                objLeavesOldStockViewModel.sessionStartDate = row[4] == DBNull.Value ? DateTime.Now : DateTime.Parse(row[4].ToString());
                objLeavesOldStockViewModel.sessionEndDate = row[5] == DBNull.Value ? DateTime.Now : DateTime.Parse(row[5].ToString());
                lstLeavesOldStockViewModel.Add(objLeavesOldStockViewModel);
            }
        }

        return lstLeavesOldStockViewModel;
    }

    #endregion

    #region Code v2.0

    public List<LeavesCount> GetLeavesCountAssignedByRole(int roleId)
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DataSet ds;
        int i = 0;
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            string query = @"SELECT LeaveTypeId,NoOfLeaves 
                             FROM tblLeaveAssignedByRole
                             WHERE RoleId = @roleId  AND
                                   IsDeleted = 0";
            List<SqlParameter> lstParams = new List<SqlParameter>(){
                 new SqlParameter("@roleId",roleId)
            };
            ds = objDDBDataHelper.GetDataSet(query, SQLTextType.Query, lstParams);

            List<LeavesCount> lstLeavesCount = new List<LeavesCount>();

            foreach (DataRow rows in ds.Tables[0].Rows)
            {
                LeavesCount objLeavesCount = new LeavesCount();

                objLeavesCount.LeaveId = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
                objLeavesCount.LeaveCount = Convert.ToInt32(ds.Tables[0].Rows[i][1]);
                lstLeavesCount.Add(objLeavesCount);
                i++;
            }
            return lstLeavesCount;
        }
    }
    public TimeSpan GetShortLeaveDurationByShiftId(int shiftId)
    {
        DataTable dt;
        TimeSpan dr = new TimeSpan();
        string query = "SELECT SHLDuration FROM tblMasterShifts WHERE Id=@shiftId AND isDeleted = 0";
        List<SqlParameter> lst_params = new List<SqlParameter> { 
            new SqlParameter("@shiftId",shiftId)
        };
        try
        {
            using (DBDataHelper helper = new DBDataHelper())
            {
                dt = helper.GetDataTable(query, SQLTextType.Query, lst_params);
                dr = dt.Rows[0][0] == DBNull.Value ? new TimeSpan(0, 0, 0) : TimeSpan.Parse(dt.Rows[0][0].ToString());
            }
        }
        catch (Exception)
        {
            dr = new TimeSpan(0, 0, 0);
        }
        return dr;
    }

    //    public List<LeavesCount> GetLeavesCountAssignedToEmployee(int employeeId, int roleId)
    //    {
    //        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
    //        DataSet ds;
    //        int i = 0;
    //        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
    //        {
    //            string query = @"SELECT LeaveTypeId,NoOfLeaves 
    //                             FROM tblLeaveAssignedByRole
    //                             WHERE RoleId = 1  AND
    //                                   IsDeleted = 0";

    //            List<SqlParameter> lstParams = new List<SqlParameter>(){
    //                 new SqlParameter("@roleId",roleId)
    //            };
    //            ds = objDDBDataHelper.GetDataSet(query, SQLTextType.Query, lstParams);

    //            List<LeavesCount> lstLeavesCount = new List<LeavesCount>();

    //            foreach (DataRow rows in ds.Tables[0].Rows)
    //            {
    //                LeavesCount objLeavesCount = new LeavesCount();

    //                objLeavesCount.LeaveId = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
    //                objLeavesCount.LeaveCount = Convert.ToInt32(ds.Tables[0].Rows[i][1]);
    //                lstLeavesCount.Add(objLeavesCount);
    //                i++;
    //            }
    //            return lstLeavesCount;
    //        }
    //    }


    #endregion
}