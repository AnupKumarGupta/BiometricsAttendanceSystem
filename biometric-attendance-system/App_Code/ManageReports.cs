using DALHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BAS.Enums;
using System.Globalization;

/// <summary>
/// Summary description for ManageReports
/// </summary>
public class ManageReports
{
    #region Old Code
    public bool GetEmployeesByDate(DateTime date, out List<Employees> objEmployees)
    {
        DataTable dt, dt1, dt2;
        List<Employees> objEmployees1 = new List<Employees>();
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        List<SqlParameter> list_params = new List<SqlParameter>() { new SqlParameter("@date", date) };
        try
        {
            using (DBDataHelper helper = new DBDataHelper())
            {
                dt = helper.GetDataTable("Select EmployeeId from tblAttendance where Date=@date", SQLTextType.Query, list_params);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int EmployeeId = Convert.ToInt32(dt.Rows[i]["EmployeeId"]);
                    List<SqlParameter> list_params2 = new List<SqlParameter>() { new SqlParameter("@employeeId", EmployeeId) };
                    dt1 = helper.GetDataTable("select FirstName,MiddleName,LastName from tblEmployeesMaster where Id=@employeeId", SQLTextType.Query, list_params2);
                    Employees objEmployee = new Employees();
                    objEmployee.FirstName = Convert.ToString(dt1.Rows[0]["FirstName"]);
                    objEmployee.MiddleName = Convert.ToString(dt1.Rows[0]["MiddleName"]);
                    objEmployee.LastName = Convert.ToString(dt1.Rows[0]["LastName"]);
                    List<SqlParameter> list_params3 = new List<SqlParameter>() { new SqlParameter("@employeeId", EmployeeId) };
                    dt2 = helper.GetDataTable("Select RoleId,DepartmentId from tblEmployees where EmployeeId=@employeeId", SQLTextType.Query, list_params3);
                    objEmployee.RoleId = Convert.ToInt32(dt2.Rows[0]["RoleId"]);
                    objEmployee.DepartmentId = Convert.ToInt32(dt2.Rows[0]["DepartmentId"]);
                    objEmployees1.Add(objEmployee);
                }
            }
            objEmployees = objEmployees1;
            return true;
        }
        catch (Exception ex)
        {
            objEmployees = null;
            return false;
        }
    }
    public bool GetEmployeesOnLeaveByDate(DateTime date, out List<Reports> objEmployees)
    {
        DataTable dt, dt1, dt2, dt3, dt4;
        List<Reports> objEmployees1 = new List<Reports>();
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        List<SqlParameter> list_params = new List<SqlParameter>() { new SqlParameter("@date", date) };
        try
        {
            using (DBDataHelper helper = new DBDataHelper())
            {
                dt = helper.GetDataTable("spGetEmployeesOnLeaveByDate", SQLTextType.Stored_Proc, list_params);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int EmployeeId = Convert.ToInt32(dt.Rows[i]["EmployeeId"]);
                    List<SqlParameter> list_params2 = new List<SqlParameter>() { new SqlParameter("@employeeId", EmployeeId) };
                    dt1 = helper.GetDataTable("select FirstName,MiddleName,LastName from tblEmployeesMaster where Id=@employeeId", SQLTextType.Query, list_params2);
                    Reports objReports = new Reports();
                    objReports.FirstName = Convert.ToString(dt1.Rows[0]["FirstName"]);
                    objReports.MiddleName = Convert.ToString(dt1.Rows[0]["MiddleName"]);
                    objReports.LastName = Convert.ToString(dt1.Rows[0]["LastName"]);
                    List<SqlParameter> list_params3 = new List<SqlParameter>() { new SqlParameter("@employeeId", EmployeeId) };
                    dt2 = helper.GetDataTable("Select RoleId,DepartmentId from tblEmployees where EmployeeId=@employeeId", SQLTextType.Query, list_params3);
                    objReports.RoleId = Convert.ToInt32(dt2.Rows[0]["RoleId"]);
                    objReports.DepartmentId = Convert.ToInt32(dt2.Rows[0]["DepartmentId"]);
                    List<SqlParameter> list_params4 = new List<SqlParameter>() { new SqlParameter("@roleId", objReports.RoleId) };
                    dt3 = helper.GetDataTable("spGetRoleById", SQLTextType.Stored_Proc, list_params4);
                    objReports.RoleName = dt3.Rows[0][0].ToString();
                    List<SqlParameter> list_params5 = new List<SqlParameter>() { new SqlParameter("@departmentId", objReports.DepartmentId) };
                    dt4 = helper.GetDataTable("spGetDepartmentById", SQLTextType.Stored_Proc, list_params5);
                    objReports.DepartmentName = dt4.Rows[0][0].ToString();
                    objEmployees1.Add(objReports);
                }
            }
            objEmployees = objEmployees1;
            return true;
        }
        catch (Exception ex)
        {
            objEmployees = null;
            return false;
        }
    }
    public bool BindDepartments(out List<Department> objDepartments)
    {
        DataTable dt;
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        List<Department> objDepartments1 = new List<Department>();
        try
        {
            using (DBDataHelper helper = new DBDataHelper())
            {
                dt = helper.GetDataTable("Select Id, Name from tblDepartment", SQLTextType.Query);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Department objDepartment = new Department();
                    objDepartment.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                    objDepartment.Name = Convert.ToString(dt.Rows[0]["Name"]);
                    objDepartments1.Add(objDepartment);
                }
            }
            objDepartments = objDepartments1;
            return true;
        }
        catch (Exception ex)
        {
            objDepartments = null;
            return false;
        }
    }
    public bool GetEmployeesByDepartment(int DepartmentId, DateTime date, out List<Employees> objEmployees)
    {
        DataTable dt, dt1, dt2;
        List<Employees> objEmployees1 = new List<Employees>();
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        List<SqlParameter> list_params = new List<SqlParameter>(){
            new SqlParameter("@date",date)};
        try
        {
            using (DBDataHelper helper = new DBDataHelper())
            {
                dt = helper.GetDataTable("Select EmployeeId from tblLeave where CreatedAt=@date", SQLTextType.Query, list_params);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int EmployeeId = Convert.ToInt32(dt.Rows[i]["EmployeeId"]);
                    List<SqlParameter> list_params2 = new List<SqlParameter>()
                    {
                        new SqlParameter("@employeeId",EmployeeId)
                    };
                    dt2 = helper.GetDataTable("Select RoleId,DepartmentId from tblEmployees where EmployeeId=@employeeId", SQLTextType.Query, list_params2);
                    if (Convert.ToInt32(dt2.Rows[0]["DepartmentId"]) == DepartmentId)
                    {
                        Employees objEmployee = new Employees();
                        objEmployee.RoleId = Convert.ToInt32(dt2.Rows[0]["RoleId"]);
                        objEmployee.DepartmentId = Convert.ToInt32(dt.Rows[0]["DepartmentId"]);
                        List<SqlParameter> list_params3 = new List<SqlParameter>() { new SqlParameter("@employeeId", EmployeeId) };
                        dt1 = helper.GetDataTable("select FirstName,MiddleName,LastName from tblEmployeesMaster where Id=@employeeId", SQLTextType.Query, list_params3);
                        objEmployee.FirstName = Convert.ToString(dt1.Rows[0]["FirstName"]);
                        objEmployee.MiddleName = Convert.ToString(dt1.Rows[0]["MiddleName"]);
                        objEmployee.LastName = Convert.ToString(dt1.Rows[0]["LastName"]);

                        objEmployees1.Add(objEmployee);
                    }
                }
            }
            objEmployees = objEmployees1;
            return true;
        }
        catch (Exception ex)
        {
            objEmployees = null;
            return false;
        }
    }
    public List<Employees> GetDefaulterEmployeesByDate(DateTime date)
    {
        List<Employees> objEmployees = new List<Employees>();
        DataTable dt;
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        List<SqlParameter> list_params = new List<SqlParameter>() { new SqlParameter("@date", date) };
        try
        {
            using (DBDataHelper helper = new DBDataHelper())
            {
                dt = helper.GetDataTable("spGetEmployeesDefaultersByDate", SQLTextType.Stored_Proc, list_params);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Employees objEmployee = new Employees();
                    objEmployee.Id = Convert.ToInt32(dt.Rows[i]["EmployeeId"]);
                    objEmployee.FirstName = (dt.Rows[0]["FirstName"]).ToString();
                    objEmployee.MiddleName = (dt.Rows[0]["MiddleName"]).ToString();
                    objEmployee.LastName = (dt.Rows[0]["LastName"]).ToString();
                    objEmployee.RoleId = Convert.ToInt32(dt.Rows[0]["RoleId"]);
                    objEmployee.DepartmentId = Convert.ToInt32(dt.Rows[0]["DepartmentId"]);
                    objEmployees.Add(objEmployee);
                }
            }
            return objEmployees;
        }
        catch (Exception ex)
        {
            return objEmployees;

        }
    }
    public object GetDefaulterEmployeesByDepartmentDateWise(DateTime date, int departmentId)
    {
        List<Employees> objEmployees = new List<Employees>();
        DataTable dt;
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        List<SqlParameter> list_params = new List<SqlParameter>();
        list_params.Add(new SqlParameter("@date", date));
        list_params.Add(new SqlParameter("@departmentId", departmentId));
        try
        {
            using (DBDataHelper helper = new DBDataHelper())
            {
                dt = helper.GetDataTable("spGetEmployeesDefaultersByDeapartmentDateWise", SQLTextType.Stored_Proc, list_params);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Employees objEmployee = new Employees();
                    objEmployee.Id = Convert.ToInt32(dt.Rows[i]["EmployeeId"]);
                    objEmployee.FirstName = (dt.Rows[0]["FirstName"]).ToString();
                    objEmployee.MiddleName = (dt.Rows[0]["MiddleName"]).ToString();
                    objEmployee.LastName = (dt.Rows[0]["LastName"]).ToString();
                    objEmployee.RoleId = Convert.ToInt32(dt.Rows[0]["RoleId"]);
                    objEmployee.DepartmentId = Convert.ToInt32(dt.Rows[0]["DepartmentId"]);
                    objEmployees.Add(objEmployee);
                }
            }
            return objEmployees;
        }
        catch (Exception ex)
        {
            return objEmployees;

        }
    }
    public List<Attendance> GetEmployeesLateByDate(DateTime date)
    {
        List<Attendance> objAttendances = new List<Attendance>();
        DataTable dt;
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        List<SqlParameter> list_params = new List<SqlParameter>() { new SqlParameter("@date", date) };
        try
        {
            using (DBDataHelper helper = new DBDataHelper())
            {
                dt = helper.GetDataTable("spGetEmployeesDefaultersByDate", SQLTextType.Stored_Proc, list_params);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Attendance objAttendance = new Attendance();
                    objAttendance.EmployeeId = Convert.ToInt32(dt.Rows[i]["EmployeeId"]);
                    objAttendance.EntryTime = Convert.ToDateTime(dt.Rows[0]["EntryTime"]);
                    objAttendances.Add(objAttendance);
                }
            }
            return objAttendances;
        }
        catch (Exception ex)
        {
            return objAttendances;
        }
    }

    //By   : Mudit Juneja 
    //Date : 19/12/2015
    //Refer: BasicReportViewModel 

    public List<BasicReportViewModel> GetDataForBasicReport(DateTime date)
    {
        List<BasicReportViewModel> lst_basic = new List<BasicReportViewModel>();
        DataTable dt, dtShifts;
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        List<SqlParameter> list_params = new List<SqlParameter>() { new SqlParameter("@date", date) };
        try
        {
            using (DBDataHelper helper = new DBDataHelper())
            {
                dt = helper.GetDataTable("spGetEmployeesForBasicReport", SQLTextType.Stored_Proc, list_params);
                dtShifts = helper.GetDataTable("spGetActiveShift", SQLTextType.Stored_Proc);

                foreach (DataRow row in dt.Rows)
                {
                    BasicReportViewModel model = new BasicReportViewModel();
                    model.EmployeeCode = Int32.Parse(row[1].ToString());
                    model.Name = row[0].ToString();
                    if (row[2] != DBNull.Value)
                    {
                        model.InTime = row[2].ToString();
                        model.OutTime = row[3] == DBNull.Value ? dtShifts.Rows[0]["SecondHalfEnd"].ToString() : row[3].ToString();
                        if (row[3] != DBNull.Value)
                            model.Status = "Present";
                        else
                            model.Status = "PresentWithNoOutPunch";

                    }
                    else
                    {
                        model.InTime = "00:00:00.0000000";
                        model.OutTime = "00:00:00.0000000";

                        ManageLeaves objManageLeaves = new ManageLeaves();
                        string TypeOfLeave;// For Later Use
                        if (objManageLeaves.IsEmployeeOnLeave(model.EmployeeCode, date, out TypeOfLeave))
                            model.Status = TypeOfLeave;
                        else
                            model.Status = "Absent";
                    }
                    model.InTime = row[2].ToString();
                    model.OutTime = row[3] == DBNull.Value ? "00:00:00.0000000" : row[3].ToString();
                    model.TotalDuration = model.Duration.ToString();
                    model.SecondHalfStartTime = dtShifts.Rows[0]["SecondHalfStart"].ToString();
                    lst_basic.Add(model);
                }
            }
        }
        catch (Exception ex)
        {
            //
        }
        return lst_basic;
    }

    //Report 3
    public List<EmployeeMonthlyBasicReportViewModel> GetDataForMonthlyEmployeeBasicReport(DateTime startDate, DateTime endDate, int empCode)
    {
        List<EmployeeMonthlyBasicReportViewModel> lst = new List<EmployeeMonthlyBasicReportViewModel>();
        DataTable dt;
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;

        try
        {
            using (DBDataHelper helper = new DBDataHelper())
            {
                for (DateTime date = startDate.Date; date < endDate.Date; date = date.AddDays(1))
                {

                    List<SqlParameter> list_params = new List<SqlParameter>() { new SqlParameter("@date", date), new SqlParameter("@employeeId", empCode) };
                    dt = helper.GetDataTable("spGetDayStatus", SQLTextType.Stored_Proc, list_params);
                    DayStatus status;
                    if (dt.Rows.Count > 0)
                    {
                        status = (DayStatus)dt.Rows[0][0];
                    }
                    else
                    {
                        status = DayStatus.Active;
                    }

                    dt = helper.GetDataTable("spGetEntriesDateAndEmployeeWise", SQLTextType.Stored_Proc, list_params);
                    foreach (DataRow row in dt.Rows)
                    {
                        EmployeeMonthlyBasicReportViewModel model = new EmployeeMonthlyBasicReportViewModel();
                        model.Date = date.ToString();
                        model.InTime = row[0].ToString();
                        model.OutTime = row[1] == DBNull.Value ? "00:00:00.0000000" : row[1].ToString();
                        lst.Add(model);
                    }
                    list_params.Clear();
                }



            }

        }
        catch (Exception ex)
        {
            //
        }
        return lst;
    }

    //Report 4
    public List<EmployeeMonthlyDetailedReportViewModel> GetDataForMonthlyEmployeeDetailedReport(DateTime startDate, DateTime endDate, int empCode)
    {
        List<EmployeeMonthlyDetailedReportViewModel> lst = new List<EmployeeMonthlyDetailedReportViewModel>();
        DataTable dt;
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        List<SqlParameter> list_params;
        try
        {
            using (DBDataHelper helper = new DBDataHelper())
            {
                for (DateTime date = startDate.Date; date < endDate.Date; date = date.AddDays(1))
                {
                    list_params = new List<SqlParameter>() { new SqlParameter("@date", date) };
                    dt = helper.GetDataTable("spGetDayStatus", SQLTextType.Stored_Proc, list_params);
                    DayStatus status;
                    if (dt.Rows.Count > 0)
                    {
                        status = (DayStatus)dt.Rows[0][0];
                    }
                    else
                    {
                        status = DayStatus.Active;
                    }
                    list_params.Clear();
                    list_params = new List<SqlParameter>() { new SqlParameter("@date", date), new SqlParameter("@employeeId", empCode) };
                    dt = helper.GetDataTable("spGetEntriesDateAndEmployeeWise", SQLTextType.Stored_Proc, list_params);
                    foreach (DataRow row in dt.Rows)
                    {
                        EmployeeMonthlyDetailedReportViewModel model = new EmployeeMonthlyDetailedReportViewModel();
                        model.Status = status == DayStatus.WeeklyOff ? Status.WeeklyOffPresent : Status.Present;
                        model.Date = date.ToString();
                        model.InTime = row[0].ToString();
                        model.OutTime = row[1] == DBNull.Value ? "00:00:00.0000000" : row[1].ToString();
                        lst.Add(model);
                    }
                    list_params.Clear();
                }



            }

        }
        catch (Exception ex)
        {
            //
        }
        return lst;
    }

    //Report 5
    public List<DayWiseInOutDurationReportViewModel> GetDataForDailyInOutDurationReport(DateTime date)
    {
        List<DayWiseInOutDurationReportViewModel> lst = new List<DayWiseInOutDurationReportViewModel>();
        DataTable dt;
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        List<SqlParameter> list_params;
        try
        {
            using (DBDataHelper helper = new DBDataHelper())
            {

                List<TimeTracker> lst_timetracker = new List<TimeTracker>();
                list_params = new List<SqlParameter>() { new SqlParameter("@date", date) };
                dt = helper.GetDataTable("spGetEntriesDateWise", SQLTextType.Stored_Proc, list_params);
                foreach (DataRow row in dt.Rows)
                {
                    TimeTracker tracker = new TimeTracker();
                    tracker.EmployeeID = Convert.ToInt32(row[0].ToString());
                    tracker.InTime = row[1].ToString();

                    //We can set the status as No Out Punch here 
                    //To DO : MUDIT JUNEJA :: PLEASE DON'T FORGET :P
                    tracker.OutTime = row[2] == DBNull.Value ? "16:10:00.0000000" : row[2].ToString();
                    lst_timetracker.Add(tracker);
                }

                foreach (var item in lst_timetracker.GroupBy(i => i.EmployeeID).Select(grp => grp.First()))
                {
                    DayWiseInOutDurationReportViewModel model = new DayWiseInOutDurationReportViewModel();
                    model.EmployeeCode = item.EmployeeID;
                    model.Tracker.AddRange(lst_timetracker.FindAll(j => j.EmployeeID == item.EmployeeID));
                    lst.Add(model);
                }

            }



        }

       // }
        catch (Exception ex)
        {
            //
        }
        return lst;
    }


    //Anup Gupta
    // 22nd Dec 2015

    //Report 7
    public List<DetailedReportViewModel> GetDataForDailyAttendancePresent(DateTime date)
    {
        List<DetailedReportViewModel> lstDailyAttendancePresentViewModel = new List<DetailedReportViewModel>();
        lstDailyAttendancePresentViewModel = GetDataForDetailedReport(date);
        lstDailyAttendancePresentViewModel = lstDailyAttendancePresentViewModel.Where(x => x.Status.ToLower() == "Present".ToLower() || x.Status.ToLower() == "PresentWithNoOutPunch".ToLower()).ToList();
        return lstDailyAttendancePresentViewModel;
    }

    #region Report 8
    //For one Day
    public List<DetailedReportViewModel> GetDataForDailyAttendanceAbsent(DateTime date)
    {
        List<DetailedReportViewModel> lstDailyAttendancePresentViewModel = new List<DetailedReportViewModel>();
        lstDailyAttendancePresentViewModel = GetDataForDetailedReport(date);
        lstDailyAttendancePresentViewModel = lstDailyAttendancePresentViewModel.Where(x => x.Status.ToLower() == "Absent".ToLower()).ToList();
        return lstDailyAttendancePresentViewModel;
    }

    //For more than one days
    public List<DetailedReportViewModel> GetDataForDailyAttendanceAbsent(DateTime StartDate, DateTime EndDate)
    {
        List<DetailedReportViewModel> lstDailyAttendancePresentViewModel = new List<DetailedReportViewModel>();

        for (DateTime date = StartDate.Date; date.Date <= EndDate.Date; date = date.AddDays(1))
        {
            List<DetailedReportViewModel> varLst = GetDataForDetailedReport(date);
            lstDailyAttendancePresentViewModel = lstDailyAttendancePresentViewModel.Concat(varLst).ToList();
        }

        lstDailyAttendancePresentViewModel = lstDailyAttendancePresentViewModel.Where(x => x.Status.ToLower() == "Absent".ToLower()).ToList();
        return lstDailyAttendancePresentViewModel;
    }
    #endregion

    //9 10 For one Day
    public List<DetailedReportViewModel> GetDataForDailyAttendanceLateComing(DateTime date)
    {
        List<DetailedReportViewModel> lstDailyAttendanceLateComingViewModel = new List<DetailedReportViewModel>();
        lstDailyAttendanceLateComingViewModel = GetDataForDetailedReport(date);
        lstDailyAttendanceLateComingViewModel = lstDailyAttendanceLateComingViewModel.Where(x => x.LateByDuration > TimeSpan.Parse("00:00:00")).ToList();
        return lstDailyAttendanceLateComingViewModel;
    }

    //9 10 For more than one days
    public List<DetailedReportViewModel> GetDataForDailyAttendanceLateComing(DateTime StartDate, DateTime EndDate)
    {
        List<DetailedReportViewModel> lstDailyAttendanceLateComingViewModel = new List<DetailedReportViewModel>();

        for (DateTime date = StartDate.Date; date.Date <= EndDate.Date; date = date.AddDays(1))
        {
            List<DetailedReportViewModel> varLst = GetDataForDetailedReport(date);
            lstDailyAttendanceLateComingViewModel = lstDailyAttendanceLateComingViewModel.Concat(varLst).ToList();
        }

        lstDailyAttendanceLateComingViewModel = lstDailyAttendanceLateComingViewModel.Where(x => x.LateByDuration > TimeSpan.Parse("00:00:00")).ToList();
        return lstDailyAttendanceLateComingViewModel;
    }

    //13 For one Day
    public List<DetailedReportViewModel> GetDataForDailyAttendanceEarlyGoing(DateTime date)
    {
        List<DetailedReportViewModel> lstDailyAttendanceEarlyGoingViewModel = new List<DetailedReportViewModel>();
        lstDailyAttendanceEarlyGoingViewModel = GetDataForDetailedReport(date);
        lstDailyAttendanceEarlyGoingViewModel = lstDailyAttendanceEarlyGoingViewModel.Where(x => x.EarlyGoingByDuration > TimeSpan.Parse("00:00:00")).ToList();
        return lstDailyAttendanceEarlyGoingViewModel;
    }

    //13 For more than one days
    public List<DetailedReportViewModel> GetDataForDailyAttendanceEarlyGoing(DateTime StartDate, DateTime EndDate)
    {
        List<DetailedReportViewModel> lstDailyAttendanceEarlyGoingViewModel = new List<DetailedReportViewModel>();

        for (DateTime date = StartDate.Date; date.Date <= EndDate.Date; date = date.AddDays(1))
        {
            List<DetailedReportViewModel> varLst = GetDataForDetailedReport(date);
            lstDailyAttendanceEarlyGoingViewModel = lstDailyAttendanceEarlyGoingViewModel.Concat(varLst).ToList();
        }

        lstDailyAttendanceEarlyGoingViewModel = lstDailyAttendanceEarlyGoingViewModel.Where(x => x.EarlyGoingByDuration > TimeSpan.Parse("00:00:00")).ToList();
        return lstDailyAttendanceEarlyGoingViewModel;
    }

    //By   : Anup Kumar Gupta
    //Date : 21/12/2015
    //Refer: BasicReportViewModel
    public List<DetailedReportViewModel> GetDataForDetailedReport(DateTime date)
    {
        List<DetailedReportViewModel> lstDetailedReportViewModel = new List<DetailedReportViewModel>();
        DataTable dt, dtShifts, dtPunchRecords;
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        List<SqlParameter> list_params = new List<SqlParameter>() { new SqlParameter("@date", date) };

        try
        {
            using (DBDataHelper helper = new DBDataHelper())
            {
                dt = helper.GetDataTable("spGetEmployeesForDetailedReport", SQLTextType.Stored_Proc, list_params);
                dtShifts = helper.GetDataTable("spGetActiveShift", SQLTextType.Stored_Proc);

                foreach (DataRow row in dt.Rows)
                {
                    DetailedReportViewModel model = new DetailedReportViewModel();
                    model.EmployeeCode = Int32.Parse(row[1].ToString());
                    model.Name = row[0].ToString();

                    if (row[2] != DBNull.Value)
                    {
                        model.InTime = row[2].ToString();
                        model.OutTime = row[3] == DBNull.Value ? dtShifts.Rows[0]["SecondHalfEnd"].ToString() : row[3].ToString();
                        if (row[3] != DBNull.Value)
                            model.Status = "Present";
                        else
                            model.Status = "PresentWithNoOutPunch";
                    }
                    else
                    {
                        model.InTime = "00:00:00.0000000";
                        model.OutTime = "00:00:00.0000000";

                        ManageLeaves objManageLeaves = new ManageLeaves();
                        string TypeOfLeave;
                        if (objManageLeaves.IsEmployeeOnLeave(model.EmployeeCode, date, out TypeOfLeave))
                            model.Status = TypeOfLeave;
                        else
                            model.Status = "Absent";
                    }

                    model.TotalDuration = model.Duration.ToString();
                    model.FirstHalfStartTime = dtShifts.Rows[0]["FirstHalfStart"].ToString();
                    model.FirstHalfEndTime = dtShifts.Rows[0]["FirstHalfEnd"].ToString();
                    model.SecondHalfStartTime = dtShifts.Rows[0]["SecondHalfStart"].ToString();
                    model.SecondHalfEndTime = dtShifts.Rows[0]["SecondHalfEnd"].ToString();
                    model.Date = date.Date;
                    List<SqlParameter> list_paramsForPunchRecords = new List<SqlParameter>();
                    list_paramsForPunchRecords.Add(new SqlParameter("@date", date));
                    list_paramsForPunchRecords.Add(new SqlParameter("@employeeId", model.EmployeeCode));
                    dtPunchRecords = helper.GetDataTable("spGetPunchRecordsOfEmployeeDateWise", SQLTextType.Stored_Proc, list_paramsForPunchRecords);
                    foreach (DataRow rowPunchRecords in dtPunchRecords.Rows)
                    {
                        model.PunchRecords += rowPunchRecords[0].ToString() + " in(AKGEC), " + rowPunchRecords[1].ToString() + " out(AKGEC). ";
                    }

                    lstDetailedReportViewModel.Add(model);
                }
            }
        }
        catch (Exception ex)
        {
            //
        }
        return lstDetailedReportViewModel;
    }
    #endregion

    #region New Code

    #region Daily Reports
    public TimeSpan GetTotalTime(int employeeId, DateTime date)
    {
        List<SqlParameter> list_paramsForTotalDuration = new List<SqlParameter>() { new SqlParameter("@date", date), new SqlParameter("@employeeId", employeeId) };
        TimeSpan totalDuration = new TimeSpan();

        DataTable dtTotalDuration;
        using (DBDataHelper helper = new DBDataHelper())
        {
            dtTotalDuration = helper.GetDataTable("spGetTotalDurationOfEmployeesDatewise", SQLTextType.Stored_Proc, list_paramsForTotalDuration);
            foreach (DataRow row in dtTotalDuration.Rows)
            {
                totalDuration = row[0] == DBNull.Value ? new TimeSpan(0, 0, 0) : new TimeSpan(0, Int32.Parse(row[0].ToString()), 0);
            }
        }
        return totalDuration;
    }
    public string GetPunchRecords(int employeeId, DateTime date)
    {
        List<SqlParameter> list_paramsForPunchRecords = new List<SqlParameter>() { new SqlParameter("@date", date), new SqlParameter("@employeeId", employeeId) };
        string punchRecords = "";
        DataTable dtPunchRecords;

        using (DBDataHelper helper = new DBDataHelper())
        {
            dtPunchRecords = helper.GetDataTable("spGetPunchRecordsOfEmployeeDateWise", SQLTextType.Stored_Proc, list_paramsForPunchRecords);
            foreach (DataRow rowPunchRecords in dtPunchRecords.Rows)
            {
                punchRecords += rowPunchRecords[0].ToString() + " in(AKGEC), " + rowPunchRecords[1].ToString() + " out(AKGEC). ";
            }
        }
        return punchRecords == "" ? "No Punch Records" : punchRecords;
    }
    public List<DailyAttendanceReportViewModel> GetDataForDailyAttendanceReport(int departmentId, DateTime date, TimeSpan relaxation)
    {

        List<DailyAttendanceReportViewModel> lstDailyAttendanceReportViewModel = new List<DailyAttendanceReportViewModel>();
        DataTable dtEmployees, dtShifts;
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        List<SqlParameter> list_params = new List<SqlParameter>() { new SqlParameter("@date", date), new SqlParameter("@departmentId", departmentId) };

        ManageLeaves objManageLeave = new ManageLeaves();
        TimeSpan tsShortLeave = objManageLeave.GetShortLeaveDuration();
        TimeSpan tsHalfLeave = objManageLeave.GetHalfDayLeaveDuration();

        try
        {
            using (DBDataHelper helper = new DBDataHelper())
            {
                dtEmployees = helper.GetDataTable("spGetEmployeesForDailyAttendanceReportByDeaprtment", SQLTextType.Stored_Proc, list_params);
                dtShifts = helper.GetDataTable("spGetActiveShift", SQLTextType.Stored_Proc);

                foreach (DataRow row in dtEmployees.Rows)
                {
                    DailyAttendanceReportViewModel objDailyAttendanceReportViewModel = new DailyAttendanceReportViewModel();

                    objDailyAttendanceReportViewModel.EmployeeId = Int32.Parse(row[1].ToString());
                    objDailyAttendanceReportViewModel.Name = row[0].ToString();
                    objDailyAttendanceReportViewModel.FirstHalfStartTime = dtShifts.Rows[0]["FirstHalfStart"].ToString();
                    objDailyAttendanceReportViewModel.SecondHalfEndTime = dtShifts.Rows[0]["SecondHalfEnd"].ToString();
                    objDailyAttendanceReportViewModel.Relaxation = relaxation.ToString();
                    objDailyAttendanceReportViewModel.Date = date;

                    if (row[2] != DBNull.Value) //Entry Time is Not  Null
                    {
                        objDailyAttendanceReportViewModel.InTime = row[2].ToString();
                        objDailyAttendanceReportViewModel.OutTime = row[3] == DBNull.Value ? dtShifts.Rows[0]["SecondHalfEnd"].ToString() : row[3].ToString();

                        if (row[3] != DBNull.Value)
                            objDailyAttendanceReportViewModel.Status = Status.Present;  //Exit Time is Not Null
                        else
                            objDailyAttendanceReportViewModel.Status = Status.PresentWithNoOutPunch; //Exit Time is Null

                        if (objDailyAttendanceReportViewModel._inTime >= objDailyAttendanceReportViewModel._firstHalfStartTime + relaxation)
                        {
                            ManageLeaves objManageLeaves = new ManageLeaves();
                            if (objDailyAttendanceReportViewModel._inTime - objDailyAttendanceReportViewModel._firstHalfStartTime >= tsHalfLeave)
                            {
                                // Assigning Half Day Leave
                                objManageLeaves.AssignLeave(objDailyAttendanceReportViewModel.EmployeeId, objDailyAttendanceReportViewModel.Date, (int)LeaveTypes.HDL);
                                objDailyAttendanceReportViewModel.Status = Status.OnHalfDayLeave;
                            }
                            else if (objDailyAttendanceReportViewModel._inTime - objDailyAttendanceReportViewModel._firstHalfStartTime >= tsShortLeave)
                            {
                                // Assigning Short Leave
                                objManageLeaves.AssignLeave(objDailyAttendanceReportViewModel.EmployeeId, objDailyAttendanceReportViewModel.Date, (int)LeaveTypes.SHL);
                                objDailyAttendanceReportViewModel.Status = Status.OnShortLeave;
                            }
                            else
                                objDailyAttendanceReportViewModel.Status = Status.Late;

                            objDailyAttendanceReportViewModel.LateByDuration = (objDailyAttendanceReportViewModel._firstHalfStartTime < objDailyAttendanceReportViewModel._inTime) ? (objDailyAttendanceReportViewModel._inTime - objDailyAttendanceReportViewModel._firstHalfStartTime).Duration() : TimeSpan.Parse("00:00:00");
                        }
                        objDailyAttendanceReportViewModel.EarlyGoingByDuration = (objDailyAttendanceReportViewModel._inTime.TimeOfDay > TimeSpan.Parse("00:00:00")) ? ((objDailyAttendanceReportViewModel._secondHalfEndTime > objDailyAttendanceReportViewModel._outTime) ? (objDailyAttendanceReportViewModel._secondHalfEndTime - objDailyAttendanceReportViewModel._outTime).Duration() : TimeSpan.Parse("00:00:00")) : TimeSpan.Parse("00:00:00");


                        objDailyAttendanceReportViewModel.Duration = GetTotalTime(objDailyAttendanceReportViewModel.EmployeeId, date);// Exit time null waali
                        if (TimeSpan.Parse(objDailyAttendanceReportViewModel.TotalDuration) > new TimeSpan(0, 0, 0)) // Iterartes only if emp is Present
                            objDailyAttendanceReportViewModel.PunchRecords = GetPunchRecords(objDailyAttendanceReportViewModel.EmployeeId, date);
                        else
                            objDailyAttendanceReportViewModel.PunchRecords = "No Punch Records"; //Employee is Absent
                        TimeSpan totalShiftDuration = objDailyAttendanceReportViewModel._secondHalfEndTime - objDailyAttendanceReportViewModel._firstHalfStartTime;

                        if (TimeSpan.Parse(objDailyAttendanceReportViewModel.TotalDuration) == new TimeSpan(0, 0, 0))
                        {
                            objDailyAttendanceReportViewModel.Status = Status.Absent;
                        }
                        else if (totalShiftDuration - objDailyAttendanceReportViewModel.Duration >= tsHalfLeave)
                        {
                            ManageLeaves objManageLeaves = new ManageLeaves();

                            // Remove short leave and assign Half leave if any short leave exists
                            objManageLeaves.AssignHalfDayLeaveRemovingShortDayLeave(objDailyAttendanceReportViewModel.EmployeeId, date);
                            objDailyAttendanceReportViewModel.Status = Status.OnHalfDayLeaveFirstHalf;
                        }
                    }

                    else
                    {
                        objDailyAttendanceReportViewModel.InTime = "00:00:00.0000000";
                        objDailyAttendanceReportViewModel.OutTime = "00:00:00.0000000";

                        ManageLeaves objManageLeaves = new ManageLeaves();
                        int TypeOfLeave;// For the type of leave
                        if (objManageLeaves.IsEmployeeOnLeave(objDailyAttendanceReportViewModel.EmployeeId, date, out TypeOfLeave))
                        {
                            objDailyAttendanceReportViewModel.Status = (Status)TypeOfLeave;
                        }
                        else
                            objDailyAttendanceReportViewModel.Status = Status.Absent; // If no leave is there then Absent

                        objDailyAttendanceReportViewModel.Duration = new TimeSpan(0, 0, 0);
                        objDailyAttendanceReportViewModel.PunchRecords = "No Punch Records"; //Employee is Absent
                    }

                    lstDailyAttendanceReportViewModel.Add(objDailyAttendanceReportViewModel);
                }
            }
        }
        catch (Exception ex)
        {
            //
        }
        return lstDailyAttendanceReportViewModel;
    }

    #endregion

    #region Report 2 and 3
    private List<DailyAttendanceReportViewModel> GetDataForDailyAttendanceByEmployeeId(int employeeId, DateTime date, TimeSpan relaxation)
    {

        List<DailyAttendanceReportViewModel> lstDailyAttendanceReportViewModel = new List<DailyAttendanceReportViewModel>();
        DataTable dtEmployees, dtShifts;
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        List<SqlParameter> list_params = new List<SqlParameter>() { new SqlParameter("@date", date), new SqlParameter("@employeeId", employeeId) };

        ManageLeaves objManageLeave = new ManageLeaves();
        TimeSpan tsShortLeave = objManageLeave.GetShortLeaveDuration();
        TimeSpan tsHalfLeave = objManageLeave.GetHalfDayLeaveDuration();

        try
        {
            using (DBDataHelper helper = new DBDataHelper())
            {
                dtEmployees = helper.GetDataTable("spGetEmployeesForDailyAttendanceReportByEmployeeId", SQLTextType.Stored_Proc, list_params);
                dtShifts = helper.GetDataTable("spGetActiveShift", SQLTextType.Stored_Proc);

                foreach (DataRow row in dtEmployees.Rows)
                {
                    DailyAttendanceReportViewModel objDailyAttendanceReportViewModel = new DailyAttendanceReportViewModel();

                    objDailyAttendanceReportViewModel.EmployeeId = Int32.Parse(row[1].ToString());
                    objDailyAttendanceReportViewModel.Name = row[0].ToString();
                    objDailyAttendanceReportViewModel.FirstHalfStartTime = dtShifts.Rows[0]["FirstHalfStart"].ToString();
                    objDailyAttendanceReportViewModel.SecondHalfEndTime = dtShifts.Rows[0]["SecondHalfEnd"].ToString();
                    objDailyAttendanceReportViewModel.Relaxation = relaxation.ToString();
                    objDailyAttendanceReportViewModel.Date = date;

                    #region If Entry is  Not Null

                    if (row[2] != DBNull.Value) //Entry Time is Not  Null
                    {
                        objDailyAttendanceReportViewModel.InTime = row[2].ToString();
                        objDailyAttendanceReportViewModel.OutTime = row[3] == DBNull.Value ? dtShifts.Rows[0]["SecondHalfEnd"].ToString() : row[3].ToString();

                        if (row[3] != DBNull.Value)
                            objDailyAttendanceReportViewModel.Status = Status.Present;  //Exit Time is Not Null
                        else
                            objDailyAttendanceReportViewModel.Status = Status.PresentWithNoOutPunch; //Exit Time is Null

                        if (objDailyAttendanceReportViewModel._inTime >= objDailyAttendanceReportViewModel._firstHalfStartTime + relaxation)
                        {
                            ManageLeaves objManageLeaves = new ManageLeaves();
                            if (objDailyAttendanceReportViewModel._inTime - objDailyAttendanceReportViewModel._firstHalfStartTime >= tsHalfLeave)
                            {
                                objDailyAttendanceReportViewModel.Status = Status.OnHalfDayLeave;
                            }
                            else if (objDailyAttendanceReportViewModel._inTime - objDailyAttendanceReportViewModel._firstHalfStartTime >= tsShortLeave)
                            {
                                objDailyAttendanceReportViewModel.Status = Status.OnShortLeave;
                            }
                            else
                                objDailyAttendanceReportViewModel.Status = Status.Late;

                            objDailyAttendanceReportViewModel.LateByDuration = (objDailyAttendanceReportViewModel._firstHalfStartTime < objDailyAttendanceReportViewModel._inTime) ? (objDailyAttendanceReportViewModel._inTime - objDailyAttendanceReportViewModel._firstHalfStartTime).Duration() : TimeSpan.Parse("00:00:00");
                        }
                        objDailyAttendanceReportViewModel.EarlyGoingByDuration = (objDailyAttendanceReportViewModel._inTime.TimeOfDay > TimeSpan.Parse("00:00:00")) ? ((objDailyAttendanceReportViewModel._secondHalfEndTime > objDailyAttendanceReportViewModel._outTime) ? (objDailyAttendanceReportViewModel._secondHalfEndTime - objDailyAttendanceReportViewModel._outTime).Duration() : TimeSpan.Parse("00:00:00")) : TimeSpan.Parse("00:00:00");


                        objDailyAttendanceReportViewModel.Duration = GetTotalTime(objDailyAttendanceReportViewModel.EmployeeId, date);// Exit time null waali
                        if (TimeSpan.Parse(objDailyAttendanceReportViewModel.TotalDuration) > new TimeSpan(0, 0, 0)) // Iterartes only if emp is Present
                            objDailyAttendanceReportViewModel.PunchRecords = GetPunchRecords(objDailyAttendanceReportViewModel.EmployeeId, date);
                        else
                            objDailyAttendanceReportViewModel.PunchRecords = "No Punch Records"; //Employee is Absent
                        TimeSpan totalShiftDuration = objDailyAttendanceReportViewModel._secondHalfEndTime - objDailyAttendanceReportViewModel._firstHalfStartTime;
                        if (TimeSpan.Parse(objDailyAttendanceReportViewModel.TotalDuration) == new TimeSpan(0, 0, 0))
                        {
                            objDailyAttendanceReportViewModel.Status = Status.Absent;
                        }
                        else if (totalShiftDuration - objDailyAttendanceReportViewModel.Duration >= tsHalfLeave)
                        {
                            ManageLeaves objManageLeaves = new ManageLeaves();
                            // Remove short leave and assign Half leave if any short leave exists
                            objManageLeaves.AssignHalfDayLeaveRemovingShortDayLeave(objDailyAttendanceReportViewModel.EmployeeId, date);
                            objDailyAttendanceReportViewModel.Status = Status.OnHalfDayLeave;
                        }
                    }
                    #endregion

                    #region Exit is Null
                    else
                    {
                        objDailyAttendanceReportViewModel.InTime = "00:00:00.0000000";
                        objDailyAttendanceReportViewModel.OutTime = "00:00:00.0000000";

                        ManageLeaves objManageLeaves = new ManageLeaves();
                        int TypeOfLeave;// For the type of leave
                        if (objManageLeaves.IsEmployeeOnLeave(objDailyAttendanceReportViewModel.EmployeeId, date, out TypeOfLeave))
                        {
                            objDailyAttendanceReportViewModel.Status = (Status)TypeOfLeave;
                        }
                        else
                            objDailyAttendanceReportViewModel.Status = Status.Absent; // If no leave is there then Absent

                        objDailyAttendanceReportViewModel.Duration = new TimeSpan(0, 0, 0);
                        objDailyAttendanceReportViewModel.PunchRecords = "No Punch Records"; //Employee is Absent
                    }
                    #endregion

                    lstDailyAttendanceReportViewModel.Add(objDailyAttendanceReportViewModel);
                }
            }
        }
        catch (Exception)
        {
        }
        return lstDailyAttendanceReportViewModel;
    }
    private DayStatus GetStatusOfDay(DateTime date)
    {
        DataTable dt;
        DayStatus status = new DayStatus();
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;

        if (date.DayOfWeek == DayOfWeek.Sunday)
            status = DayStatus.WeeklyOff;

        List<SqlParameter> list_params = new List<SqlParameter>() { new SqlParameter("@date", date) };
        string query = "SELECT Count(Date) As Count FROM [BiometricsAttendanceSystem].[dbo].[tblHolidays] WHERE [Status] =1 AND Date =@date";
        try
        {
            using (DBDataHelper helper = new DBDataHelper())
            {
                dt = helper.GetDataTable(query, SQLTextType.Query, list_params);
            }
            if (int.Parse(dt.Rows[0][0].ToString()) > 0)
                status = DayStatus.Holiday;
            else
                status = DayStatus.Active;
        }
        catch (Exception ex)
        {

        }
        return status;
    }
    public List<DailyAttendanceReportViewModel> GetDataForMonthlyAttendanceReportByEmployeeId(int EmployeeId, DateTime StartDate, DateTime EndDate, TimeSpan relaxation, out MonthlyReportOfEmployee objMonthlyReportOfEmployee)
    {
        List<DailyAttendanceReportViewModel> lstDailyAttendanceReportViewModel = new List<DailyAttendanceReportViewModel>();
        for (DateTime date = StartDate.Date; date.Date <= EndDate.Date; date = date.AddDays(1))
        {
            List<DailyAttendanceReportViewModel> varLst = GetDataForDailyAttendanceByEmployeeId(EmployeeId, date, relaxation);

            lstDailyAttendanceReportViewModel = lstDailyAttendanceReportViewModel.Concat(varLst).ToList();
        }
        objMonthlyReportOfEmployee = new MonthlyReportOfEmployee();
        foreach (DailyAttendanceReportViewModel item in lstDailyAttendanceReportViewModel)
        {
            objMonthlyReportOfEmployee.TotalDuration += item.Duration;
            DayStatus daystatus = GetStatusOfDay(item.Date);
            if (daystatus == DayStatus.Active)
            {
                if (item.Status == Status.Present || item.Status == Status.PresentWithNoOutPunch)
                {
                    objMonthlyReportOfEmployee.PresentDays++;
                }
                else
                {
                    objMonthlyReportOfEmployee.AbsentDays++;
                }
            }
            else if (daystatus == DayStatus.WeeklyOff)
            {
                if (item.Status == Status.Present)
                {
                    item.Status = Status.WeeklyOffPresent;
                    objMonthlyReportOfEmployee.PresentDays++;
                }
                else if (item.Status == Status.PresentWithNoOutPunch)
                {
                    item.Status = Status.WeeklyOffPresentWithNoOutPunch;
                    objMonthlyReportOfEmployee.PresentDays++;
                }
                else
                {
                    item.Status = Status.WeeklyOff;
                }
            }
            else //Holiday
            {
                objMonthlyReportOfEmployee.Holidays++;
                item.Status = Status.Holiday;
            }
        }
        return lstDailyAttendanceReportViewModel;
    }

    #endregion

    #region Monthly Reports
    public List<DailyAttendanceReportViewModel> GetDataForMonthlyReport(int departmentId, DateTime date, TimeSpan relaxation)
    {
        List<DailyAttendanceReportViewModel> lstDailyAttendanceReportViewModel = new List<DailyAttendanceReportViewModel>();
        DataTable dtEmployees, dtShifts;
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        List<SqlParameter> list_params = new List<SqlParameter>() { new SqlParameter("@date", date), new SqlParameter("@departmentId", departmentId) };

        ManageLeaves objManageLeave = new ManageLeaves();
        TimeSpan tsShortLeave = objManageLeave.GetShortLeaveDuration();
        TimeSpan tsHalfLeave = objManageLeave.GetHalfDayLeaveDuration();

        try
        {
            using (DBDataHelper helper = new DBDataHelper())
            {
                dtEmployees = helper.GetDataTable("spGetEmployeesForDailyAttendanceReportByDeaprtment", SQLTextType.Stored_Proc, list_params);
                dtShifts = helper.GetDataTable("spGetActiveShift", SQLTextType.Stored_Proc);

                foreach (DataRow row in dtEmployees.Rows)
                {
                    DailyAttendanceReportViewModel objDailyAttendanceReportViewModel = new DailyAttendanceReportViewModel();

                    objDailyAttendanceReportViewModel.EmployeeId = Int32.Parse(row[1].ToString());
                    objDailyAttendanceReportViewModel.Name = row[0].ToString();
                    objDailyAttendanceReportViewModel.FirstHalfStartTime = dtShifts.Rows[0]["FirstHalfStart"].ToString();
                    objDailyAttendanceReportViewModel.SecondHalfEndTime = dtShifts.Rows[0]["SecondHalfEnd"].ToString();
                    objDailyAttendanceReportViewModel.Relaxation = relaxation.ToString();
                    objDailyAttendanceReportViewModel.Date = date;

                    if (row[2] != DBNull.Value) //Entry Time is Not  Null
                    {
                        objDailyAttendanceReportViewModel.InTime = row[2].ToString();
                        objDailyAttendanceReportViewModel.OutTime = row[3] == DBNull.Value ? dtShifts.Rows[0]["SecondHalfEnd"].ToString() : row[3].ToString();

                        if (row[3] != DBNull.Value)
                            objDailyAttendanceReportViewModel.Status = Status.Present;  //Exit Time is Not Null
                        else
                            objDailyAttendanceReportViewModel.Status = Status.PresentWithNoOutPunch; //Exit Time is Null

                        if (objDailyAttendanceReportViewModel._inTime >= objDailyAttendanceReportViewModel._firstHalfStartTime + relaxation)
                        {
                            ManageLeaves objManageLeaves = new ManageLeaves();
                            if (objDailyAttendanceReportViewModel._inTime - objDailyAttendanceReportViewModel._firstHalfStartTime >= tsHalfLeave)
                            {
                                objDailyAttendanceReportViewModel.Status = Status.OnHalfDayLeave;
                            }
                            else if (objDailyAttendanceReportViewModel._inTime - objDailyAttendanceReportViewModel._firstHalfStartTime >= tsShortLeave)
                            {
                                objDailyAttendanceReportViewModel.Status = Status.OnShortLeave;
                            }
                            else
                                objDailyAttendanceReportViewModel.Status = Status.Late;

                            objDailyAttendanceReportViewModel.LateByDuration = (objDailyAttendanceReportViewModel._firstHalfStartTime < objDailyAttendanceReportViewModel._inTime) ? (objDailyAttendanceReportViewModel._inTime - objDailyAttendanceReportViewModel._firstHalfStartTime).Duration() : TimeSpan.Parse("00:00:00");
                        }
                        objDailyAttendanceReportViewModel.EarlyGoingByDuration = (objDailyAttendanceReportViewModel._inTime.TimeOfDay > TimeSpan.Parse("00:00:00")) ? ((objDailyAttendanceReportViewModel._secondHalfEndTime > objDailyAttendanceReportViewModel._outTime) ? (objDailyAttendanceReportViewModel._secondHalfEndTime - objDailyAttendanceReportViewModel._outTime).Duration() : TimeSpan.Parse("00:00:00")) : TimeSpan.Parse("00:00:00");


                        objDailyAttendanceReportViewModel.Duration = GetTotalTime(objDailyAttendanceReportViewModel.EmployeeId, date);// Exit time null waali
                        if (TimeSpan.Parse(objDailyAttendanceReportViewModel.TotalDuration) > new TimeSpan(0, 0, 0)) // Iterartes only if emp is Present
                            objDailyAttendanceReportViewModel.PunchRecords = GetPunchRecords(objDailyAttendanceReportViewModel.EmployeeId, date);
                        else
                            objDailyAttendanceReportViewModel.PunchRecords = "No Punch Records"; //Employee is Absent
                        TimeSpan totalShiftDuration = objDailyAttendanceReportViewModel._secondHalfEndTime - objDailyAttendanceReportViewModel._firstHalfStartTime;

                        if (TimeSpan.Parse(objDailyAttendanceReportViewModel.TotalDuration) == new TimeSpan(0, 0, 0))
                        {
                            objDailyAttendanceReportViewModel.Status = Status.Absent;
                        }
                        else if (totalShiftDuration - objDailyAttendanceReportViewModel.Duration >= tsHalfLeave)
                        {
                            //ManageLeaves objManageLeaves = new ManageLeaves();
                            //objManageLeaves.AssignLeave(objDailyAttendanceReportViewModel.EmployeeId, objDailyAttendanceReportViewModel.Date, (int)LeaveTypes.HDL);
                            objDailyAttendanceReportViewModel.Status = Status.OnHalfDayLeave;
                        }
                    }

                    else
                    {
                        objDailyAttendanceReportViewModel.InTime = "00:00:00.0000000";
                        objDailyAttendanceReportViewModel.OutTime = "00:00:00.0000000";

                        ManageLeaves objManageLeaves = new ManageLeaves();
                        int TypeOfLeave;// For the type of leave
                        if (objManageLeaves.IsEmployeeOnLeave(objDailyAttendanceReportViewModel.EmployeeId, date, out TypeOfLeave))
                        {
                            objDailyAttendanceReportViewModel.Status = (Status)TypeOfLeave;
                        }
                        else
                            objDailyAttendanceReportViewModel.Status = Status.Absent; // If no leave is there then Absent

                        objDailyAttendanceReportViewModel.Duration = new TimeSpan(0, 0, 0);
                        objDailyAttendanceReportViewModel.PunchRecords = "No Punch Records"; //Employee is Absent
                    }
                    lstDailyAttendanceReportViewModel.Add(objDailyAttendanceReportViewModel);
                }
            }
        }
        catch (Exception ex)
        {
            //
        }

        return lstDailyAttendanceReportViewModel;
    }
    public List<DailyAttendanceReportViewModel> GetDataForMonthlyPresentReport(int departmentId, DateTime startDate, DateTime endDate, TimeSpan relaxation)
    {
        List<DailyAttendanceReportViewModel> lstDailyAttendanceReportViewModel = new List<DailyAttendanceReportViewModel>();
        for (DateTime date = startDate.Date; date.Date <= endDate.Date; date = date.AddDays(1))
        {
            List<DailyAttendanceReportViewModel> varLst = GetDataForMonthlyReport(departmentId, date, relaxation);

            lstDailyAttendanceReportViewModel = lstDailyAttendanceReportViewModel.Concat(varLst).ToList();
        }
        lstDailyAttendanceReportViewModel = lstDailyAttendanceReportViewModel.Where(x => x.Status == Status.Present || x.Status == Status.PresentWithNoOutPunch || x.Status == Status.OnShortLeave || x.Status == Status.OnHalfDayLeave).ToList();

        return lstDailyAttendanceReportViewModel;
    }
    public List<DailyAttendanceReportViewModel> GetDataForMonthlyAbsentReport(int departmentId, DateTime startDate, DateTime endDate, TimeSpan relaxation)
    {
        List<DailyAttendanceReportViewModel> lstDailyAttendanceReportViewModel = new List<DailyAttendanceReportViewModel>();
        for (DateTime date = startDate.Date; date.Date <= endDate.Date; date = date.AddDays(1))
        {
            List<DailyAttendanceReportViewModel> varLst = GetDataForMonthlyReport(departmentId, date, relaxation);

            lstDailyAttendanceReportViewModel = lstDailyAttendanceReportViewModel.Concat(varLst).ToList();
        }
        lstDailyAttendanceReportViewModel = lstDailyAttendanceReportViewModel.Where(x => x.Status == Status.Absent).ToList();

        return lstDailyAttendanceReportViewModel;
    }
    public List<DailyAttendanceReportViewModel> GetDataForMonthlyLateReport(int departmentId, DateTime startDate, DateTime endDate, TimeSpan relaxation)
    {
        List<DailyAttendanceReportViewModel> lstDailyAttendanceReportViewModel = new List<DailyAttendanceReportViewModel>();
        for (DateTime date = startDate.Date; date.Date <= endDate.Date; date = date.AddDays(1))
        {
            List<DailyAttendanceReportViewModel> varLst = GetDataForMonthlyReport(departmentId, date, relaxation);

            lstDailyAttendanceReportViewModel = lstDailyAttendanceReportViewModel.Concat(varLst).ToList();
        }
        lstDailyAttendanceReportViewModel = lstDailyAttendanceReportViewModel.Where(x => x._inTime >= x._firstHalfStartTime + relaxation).ToList();
        return lstDailyAttendanceReportViewModel;
    }
    public List<DailyAttendanceReportViewModel> GetDataForMonthlyLeaveReport(int departmentId, DateTime startDate, DateTime endDate, TimeSpan relaxation)
    {
        List<DailyAttendanceReportViewModel> lstDailyAttendanceReportViewModel = new List<DailyAttendanceReportViewModel>();
        for (DateTime date = startDate.Date; date.Date <= endDate.Date; date = date.AddDays(1))
        {
            List<DailyAttendanceReportViewModel> varLst = GetDataForMonthlyReport(departmentId, date, relaxation);

            lstDailyAttendanceReportViewModel = lstDailyAttendanceReportViewModel.Concat(varLst).ToList();
        }
        lstDailyAttendanceReportViewModel = lstDailyAttendanceReportViewModel.Where(x => x.Status == Status.OnCL || x.Status == Status.OnEL).ToList();
        lstDailyAttendanceReportViewModel = lstDailyAttendanceReportViewModel.Where(x => x.Status == Status.OnHalfDayLeave || x.Status == Status.OnShortLeave).ToList();
        return lstDailyAttendanceReportViewModel;
    }
    #endregion

    #region Leave Balance Table

    public List<LeavesCount> GetLeavesDueOfEmployee(int employeeId, DateTime Date)
    {
        DataTable dtAssignedLeaves, dtLeavesAvailed;
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        List<LeavesCount> lstLeavesAssigned = new List<LeavesCount>();
        List<LeavesCount> lstLeavesAvailed = new List<LeavesCount>();
        List<LeavesCount> lstLeavesDue = new List<LeavesCount>();

        #region Leaves Assigned Count
        DateTime sessionStartDate = (Date.Month >= 8) ? new DateTime(Date.Year, 8, 01) : new DateTime(Date.Year - 1, 8, 01);
        DateTime sessionEndDate = (Date.Month <= 7) ? new DateTime(Date.Year, 7, 31) : new DateTime(Date.Year + 1, 7, 31);

        using (DBDataHelper helper = new DBDataHelper())
        {
            List<SqlParameter> list_params_Assigned = new List<SqlParameter>()
            {   new SqlParameter("@employeeId", employeeId), 
                new SqlParameter("@sessionStartDate", sessionStartDate),
                new SqlParameter("@sessionEndDate", sessionEndDate)
            };
            dtAssignedLeaves = helper.GetDataTable("spGetLeavesAssignedToEmployeeSessionWise", SQLTextType.Stored_Proc, list_params_Assigned);
            foreach (DataRow row in dtAssignedLeaves.Rows)
            {
                LeavesCount objLeavesCount = new LeavesCount();
                objLeavesCount.LeaveId = row[0] == DBNull.Value ? 0 : Int32.Parse(row[0].ToString());
                objLeavesCount.LeaveName = row[1] == DBNull.Value ? "" : row[1].ToString();
                objLeavesCount.LeaveCount = row[2] == DBNull.Value ? 0 : Int32.Parse(row[2].ToString());
                lstLeavesAssigned.Add(objLeavesCount);
            }
        }
        #endregion

        #region Leaves Availed Upto That Month
        using (DBDataHelper helper = new DBDataHelper())
        {
            DateTime SessionStartDate = new DateTime();
            DateTime SessionEndDate = new DateTime();
            if (Date.Month > 7)
            {
                SessionStartDate = new DateTime(Date.Year, 08, 01);
                SessionEndDate = new DateTime(Date.Year + 1, 07, 31);
            }
            else
            {
                SessionStartDate = new DateTime(Date.Year - 1, 08, 01);
                SessionEndDate = new DateTime(Date.Year, 07, 31);
            }

            List<SqlParameter> list_params = new List<SqlParameter>()
            { 
                new SqlParameter("@employeeId", employeeId), 
                new SqlParameter("@sessionStart", SessionStartDate), 
                new SqlParameter("@sessionEnd", SessionEndDate), 
                new SqlParameter("@monthStartDate", Date)
            };

            dtLeavesAvailed = helper.GetDataTable("spGetLeavesAvailedUptoPreviousMonthEmployeeWise", SQLTextType.Stored_Proc, list_params);

            foreach (DataRow row in dtLeavesAvailed.Rows)
            {
                LeavesCount objLeavesCount = new LeavesCount();
                objLeavesCount.LeaveId = row[0] == DBNull.Value ? 0 : Int32.Parse(row[0].ToString());
                objLeavesCount.LeaveName = row[1] == DBNull.Value ? "" : row[1].ToString();
                objLeavesCount.LeaveCount = row[2] == DBNull.Value ? 0 : Int32.Parse(row[2].ToString());
                lstLeavesAvailed.Add(objLeavesCount);
            }
        }

        #endregion

        #region Leaves Due
        foreach (LeavesCount item in lstLeavesAssigned)
        {
            LeavesCount objLeavesCount = new LeavesCount();
            objLeavesCount.LeaveId = item.LeaveId;
            objLeavesCount.LeaveName = item.LeaveName;
            objLeavesCount.LeaveCount = item.LeaveCount - (lstLeavesAvailed.Select(x => x).Where(y => y.LeaveId == item.LeaveId).FirstOrDefault()).LeaveCount;
            lstLeavesDue.Add(objLeavesCount);
        }
        #endregion

        return lstLeavesDue;
    }
    public List<LeavesCount> GetLeavesAvailedByEmployee(int employeeId, DateTime monthStart, DateTime monthEnd)
    {
        DataTable dtLeavesAvailed;
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        List<LeavesCount> lstLeavesAvailed = new List<LeavesCount>();

        #region Leaves Availed  That Month
        using (DBDataHelper helper = new DBDataHelper())
        {

            List<SqlParameter> list_params = new List<SqlParameter>()
            { 
                new SqlParameter("@employeeId", employeeId), 
                new SqlParameter("@monthStartDate", monthStart), 
                new SqlParameter("@monthEndDate", monthEnd)
            };

            dtLeavesAvailed = helper.GetDataTable("spGetLeavesAvailedByMonthEmployeeWise", SQLTextType.Stored_Proc, list_params);

            foreach (DataRow row in dtLeavesAvailed.Rows)
            {
                LeavesCount objLeavesCount = new LeavesCount();
                objLeavesCount.LeaveId = row[0] == DBNull.Value ? 0 : Int32.Parse(row[0].ToString());
                objLeavesCount.LeaveName = row[1] == DBNull.Value ? "" : row[1].ToString();
                objLeavesCount.LeaveCount = row[2] == DBNull.Value ? 0 : Int32.Parse(row[2].ToString());
                lstLeavesAvailed.Add(objLeavesCount);
            }
        }

        #endregion
        return lstLeavesAvailed;
    }
    public List<LeavesCount> GetLeavesBalanceByEmployee(List<LeavesCount> lstLeavesDueOfEmployee, List<LeavesCount> lstLeavesAvailedByEmployee)
    {
        List<LeavesCount> lstLeavesBalance = new List<LeavesCount>();
        foreach (LeavesCount item in lstLeavesDueOfEmployee)
        {
            LeavesCount objLeavesCount = new LeavesCount();
            objLeavesCount.LeaveId = item.LeaveId;
            objLeavesCount.LeaveName = item.LeaveName;
            objLeavesCount.LeaveCount = item.LeaveCount - (lstLeavesAvailedByEmployee.Select(x => x).Where(y => y.LeaveId == item.LeaveId).FirstOrDefault()).LeaveCount;
            lstLeavesBalance.Add(objLeavesCount);
        }
        return lstLeavesBalance;
    }
    public List<LeavesBalanceRecord> GetDataForMonthlyLeaveBalanceTable(int departmentId, DateTime startDate, DateTime endDate)
    {
        List<LeavesBalanceRecord> lstLeavesBalanceRecord = new List<LeavesBalanceRecord>();

        DataTable dtEmployees;
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        List<SqlParameter> list_params = new List<SqlParameter>() { new SqlParameter("@departmentId", departmentId) };
        try
        {
            using (DBDataHelper helper = new DBDataHelper())
            {
                dtEmployees = helper.GetDataTable("spGetLeavesOldStockDepartmentWise", SQLTextType.Stored_Proc, list_params);
                foreach (DataRow row in dtEmployees.Rows)
                {
                    LeavesBalanceRecord objLeavesBalanceRecord = new LeavesBalanceRecord();

                    objLeavesBalanceRecord.EmployeeId = Int32.Parse(row[0].ToString());
                    objLeavesBalanceRecord.Name = row[1].ToString();
                    List<LeavesCount> LeavesOldStack = new List<LeavesCount>()
                    {
                        new LeavesCount {
                            LeaveId = (int)BAS.Enums.LeaveTypes.SL,
                            LeaveName=BAS.Enums.LeaveTypes.SL.ToString(), 
                            LeaveCount = row[2] == DBNull.Value ? 0: Int32.Parse(row[2].ToString())
                        },
                        new LeavesCount {
                            LeaveId = (int)BAS.Enums.LeaveTypes.EL, 
                            LeaveName=BAS.Enums.LeaveTypes.EL.ToString(),
                            LeaveCount = row[3] == DBNull.Value ? 0: Int32.Parse(row[3].ToString())
                        }
                    };
                    objLeavesBalanceRecord.lstLeavesOldStack = LeavesOldStack;
                    objLeavesBalanceRecord.lstLeavesDue = GetLeavesDueOfEmployee(objLeavesBalanceRecord.EmployeeId, startDate);
                    objLeavesBalanceRecord.lstLeavesAvailed = GetLeavesAvailedByEmployee(objLeavesBalanceRecord.EmployeeId, startDate, endDate);
                    objLeavesBalanceRecord.lstLeavesBalance = GetLeavesBalanceByEmployee(objLeavesBalanceRecord.lstLeavesDue, objLeavesBalanceRecord.lstLeavesAvailed);

                    lstLeavesBalanceRecord.Add(objLeavesBalanceRecord);
                }
            }
        }
        catch (Exception ex)
        {

        }
        return lstLeavesBalanceRecord;
    }

    #endregion

    #region Update Leave Balance
    public void UpdateLeaveBalanceTable(DateTime OldSessionStartDate, DateTime OldSessionEndDate, DateTime NewSessionStartDate, DateTime NewSessionEndDate)
    {
        MasterEntries objMasterEntries = new MasterEntries();
        List<Departments> lstDepartments = objMasterEntries.GetAllDepartments();
        foreach (var item in lstDepartments)
        {
            //List<LeavesBalanceRecord> lst = GetDataForMonthlyLeaveBalanceTable();

        }
    }

    #endregion

    #endregion

    #region New Code v2.0
    public List<LeavesCount> GetLeavesAssignedPerSessionEmployeeWise(int employeeId, DateTime Date)
    {
        DataTable dtAssignedLeaves;
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        List<LeavesCount> lstLeavesAssigned = new List<LeavesCount>();

        DateTime sessionStartDate = (Date.Month >= 8) ? new DateTime(Date.Year, 8, 01) : new DateTime(Date.Year - 1, 8, 01);
        DateTime sessionEndDate = (Date.Month <= 7) ? new DateTime(Date.Year, 7, 31) : new DateTime(Date.Year + 1, 7, 31);

        using (DBDataHelper helper = new DBDataHelper())
        {
            List<SqlParameter> list_params_Assigned = new List<SqlParameter>()
            {   new SqlParameter("@employeeId", employeeId), 
                new SqlParameter("@sessionStartDate", sessionEndDate),
                new SqlParameter("@sessionEndDate", sessionEndDate)
            };
            dtAssignedLeaves = helper.GetDataTable("spGetLeavesAssignedToEmployeeSessionWise", SQLTextType.Stored_Proc, list_params_Assigned);
            foreach (DataRow row in dtAssignedLeaves.Rows)
            {
                LeavesCount objLeavesCount = new LeavesCount();
                objLeavesCount.LeaveId = row[0] == DBNull.Value ? 0 : Int32.Parse(row[0].ToString());
                objLeavesCount.LeaveName = row[1] == DBNull.Value ? "" : row[1].ToString();
                objLeavesCount.LeaveCount = row[2] == DBNull.Value ? 0 : Int32.Parse(row[2].ToString());
                lstLeavesAssigned.Add(objLeavesCount);
            }
        }
        return lstLeavesAssigned;
    }
    public List<LeaveAssignedRecord> GetLeavesAssignedPerSession(int departmentId, DateTime startDate)
    {
        DataTable dtAssignedLeaves;
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        List<LeaveAssignedRecord> lstLeaveAssignedRecord = new List<LeaveAssignedRecord>();
        string query = @"Select EmployeeId,Name 
                         FROM tblEmployees Join tblEmployeesMaster on tblEmployees.EmployeeId = tblEmployeesMaster.id 
                         WHERE departmentid= @departmentid";
        List<SqlParameter> list_params_Assigned = new List<SqlParameter>() { new SqlParameter("@departmentid", departmentId) };

        using (DBDataHelper helper = new DBDataHelper())
        {
            dtAssignedLeaves = helper.GetDataTable(query, SQLTextType.Query, list_params_Assigned);
            foreach (DataRow row in dtAssignedLeaves.Rows)
            {
                LeaveAssignedRecord objLeaveAssignedRecord = new LeaveAssignedRecord();
                objLeaveAssignedRecord.EmployeeId = row[0] == DBNull.Value ? 0 : Int32.Parse(row[0].ToString());
                objLeaveAssignedRecord.EmployeeName = row[1] == DBNull.Value ? "" : row[1].ToString();
                objLeaveAssignedRecord.lstAssignedRecord = GetLeavesAssignedPerSessionEmployeeWise(objLeaveAssignedRecord.EmployeeId, startDate);
                lstLeaveAssignedRecord.Add(objLeaveAssignedRecord);
            }
        }
        return lstLeaveAssignedRecord;
    }

    #region Leave Assinged Per Session
    public bool UpdateLeavesAssignedPerSessionEmployeeWise(LeaveAssignedPerSession objLeaveAssignedPerSession, DateTime sessionStartDate, DateTime sessionEndDate)
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;

        List<SqlParameter> lstParams = new List<SqlParameter>();

        lstParams.Add(new SqlParameter("@employeeId", objLeaveAssignedPerSession.EmployeeId));
        lstParams.Add(new SqlParameter("@leaveTypeId", objLeaveAssignedPerSession.leaveType));
        lstParams.Add(new SqlParameter("@noOfLeaves", objLeaveAssignedPerSession.leaveCount));
        lstParams.Add(new SqlParameter("@sessionStartDate", sessionStartDate));
        lstParams.Add(new SqlParameter("@sessionEndDate", sessionEndDate));
        try
        {
            using (DBDataHelper objDDBDataHelper = new DBDataHelper())
            {
                objDDBDataHelper.ExecSQL("spUpdateLeavesAssignedPerSession", SQLTextType.Stored_Proc, lstParams);
            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    public bool AddLeavesAssginedPerSessionRoleWise(DateTime sessionStartDate)
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        MasterEntries objMasterEntries = new MasterEntries();
        List<Role> lstRole = new List<Role>();
        lstRole = objMasterEntries.GetAllRoles();
        DateTime sessionEndDate = new DateTime(sessionStartDate.Year + 1, 7, 31);

        #region Roles

        foreach (Role role in lstRole)
        {
            ManageEmployees objManageEmployees = new ManageEmployees();

            List<Employees> lstEmployees = objManageEmployees.GetEmployeesByRole(role.Id);
            List<LeavesCount> lstLeaveDetails = new List<LeavesCount>();
            ManageLeaves objManageLeaves = new ManageLeaves();
            lstLeaveDetails = objManageLeaves.GetLeavesCountAssignedByRole(role.Id);

            #region List of Employees

            foreach (Employees objEmployees in lstEmployees)
            {
                #region List of Leaves

                foreach (LeavesCount LeaveDetails in lstLeaveDetails)
                {

                    using (DBDataHelper objDDBDataHelper = new DBDataHelper())
                    {
                        string query = @"INSERT INTO [dbo].[tblLeaveAssignedPerSession]
                                 VALUES
                                (@employeeId,
                                 @leaveTypeId, 
                                 @noOfLeaves,
                                 @sessionStartDate,
                                 @sessionEndDate)";

                        List<SqlParameter> list_params = new List<SqlParameter>() 
                        { 
                            new SqlParameter("@employeeId", objEmployees.Id),
                            new SqlParameter("@leaveTypeId", LeaveDetails.LeaveId),
                            new SqlParameter("@noOfLeaves", LeaveDetails.LeaveCount),
                            new SqlParameter("@sessionStartDate", sessionStartDate),
                            new SqlParameter("@sessionEndDate", sessionEndDate),
                        };

                        objDDBDataHelper.ExecSQL(query, SQLTextType.Query, list_params);
                    }
                }

                #endregion
            }

            #endregion
        }
        #endregion

        return true;
    }

    #endregion

    #region Basic Working
    public TimeSpan GetDurationOfEmployeeDateWise(int employeeId, DateTime date)
    {
        List<SqlParameter> list_paramsForTotalDuration = new List<SqlParameter>() { new SqlParameter("@date", date), new SqlParameter("@employeeId", employeeId) };
        TimeSpan totalDuration = new TimeSpan();

        DataTable dtTotalDuration;
        using (DBDataHelper helper = new DBDataHelper())
        {
            dtTotalDuration = helper.GetDataTable("spGetTotalDurationOfEmployeesDatewise", SQLTextType.Stored_Proc, list_paramsForTotalDuration);
            foreach (DataRow row in dtTotalDuration.Rows)
            {
                totalDuration = row[0] == DBNull.Value ? new TimeSpan(0, 0, 0) : new TimeSpan(0, Int32.Parse(row[0].ToString()), 0);
            }
        }
        return totalDuration;
    }
    public string GetPunchRecordsEmployeeDateWise(int employeeId, DateTime date)
    {
        List<SqlParameter> list_paramsForPunchRecords = new List<SqlParameter>() { new SqlParameter("@date", date), new SqlParameter("@employeeId", employeeId) };
        string punchRecords = "";
        DataTable dtPunchRecords;

        using (DBDataHelper helper = new DBDataHelper())
        {
            dtPunchRecords = helper.GetDataTable("spGetPunchRecordsOfEmployeeDateWise", SQLTextType.Stored_Proc, list_paramsForPunchRecords);
            foreach (DataRow rowPunchRecords in dtPunchRecords.Rows)
            {
                punchRecords += rowPunchRecords[0].ToString() + " in(AKGEC), " + rowPunchRecords[1].ToString() + " out(AKGEC). ";
            }
        }
        return punchRecords == "" ? "No Punch Records" : punchRecords;
    }
    public MasterShifts GetShiftForEmployee(int employeeId)
    {
        string query = @"Select tblMasterShifts.Id,tblMasterShifts.Name,tblMasterShifts.FirstHalfStart,tblMasterShifts.FirstHalfEnd,
                        tblMasterShifts.SecondHalfStart,tblMasterShifts.SecondHalfEnd,tblMasterShifts.SHLDuration
                        FROM tblMasterShifts,tblEmployees 
                        WHERE EmployeeId=@employeeId AND
		                tblMasterShifts.Id = tblEmployees.ShiftId AND
		                tblMasterShifts.isDeleted = 0";
        List<SqlParameter> list_params = new List<SqlParameter>()
        {
            new SqlParameter("@employeeId",employeeId)
        };

        DataTable dt;
        using (DBDataHelper helper = new DBDataHelper())
        {
            dt = helper.GetDataTable(query, SQLTextType.Query, list_params);
        }
        MasterShifts objMasterShift = new MasterShifts();
        if (dt.Rows.Count > 0)
        {
            objMasterShift.Id = (dt.Rows[0][0] == DBNull.Value) ? 0 : Convert.ToInt32(dt.Rows[0][0]);
            objMasterShift.Name = (dt.Rows[0][1] == DBNull.Value) ? string.Empty : (dt.Rows[0][1]).ToString();
            objMasterShift.FirstHalfStart = (dt.Rows[0][2] == DBNull.Value) ? new TimeSpan() : (TimeSpan)(dt.Rows[0][2]);
            objMasterShift.FirstHalfEnd = (dt.Rows[0][3] == DBNull.Value) ? new TimeSpan() : (TimeSpan)(dt.Rows[0][3]);
            objMasterShift.SecondHalfStart = (dt.Rows[0][4] == DBNull.Value) ? new TimeSpan() : (TimeSpan)(dt.Rows[0][4]);
            objMasterShift.SecondHalfEnd = (dt.Rows[0][5] == DBNull.Value) ? new TimeSpan() : (TimeSpan)(dt.Rows[0][5]);
            objMasterShift.SHLDuration = (dt.Rows[0][6] == DBNull.Value) ? new TimeSpan() : (TimeSpan)(dt.Rows[0][6]);
        }
        return objMasterShift;
    }
    public int GetWeeklyOffForEmployee(int EmployeeId)
    {
        string query = @"select WeeklyOffDay from tblEmployees where EmployeeId = @employeeId ";
        List<SqlParameter> list_params = new List<SqlParameter>()
        {
            new SqlParameter("@employeeId",EmployeeId)
        };

        DataTable dt;
        using (DBDataHelper helper = new DBDataHelper())
        {
            dt = helper.GetDataTable(query, SQLTextType.Query, list_params);
        }
        int weeklyOff = Convert.ToInt32(dt.Rows[0][0]);
        return weeklyOff;
    }
    private DayStatus GetStatusOfDayEmployeeWise(DateTime date, int employeeId)
    {
        DataTable dt;
        DayStatus status = new DayStatus();
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;

        int weeklyOffDay = GetWeeklyOffForEmployee(employeeId);

        if ((int)date.DayOfWeek == weeklyOffDay)
        {
            status = DayStatus.WeeklyOff;
        }
        else
        {
            List<SqlParameter> list_params = new List<SqlParameter>() { new SqlParameter("@date", date) };
            string query = "SELECT Count(Date) As Count FROM [BiometricsAttendanceSystem].[dbo].[tblHolidays] WHERE [Status] =1 AND Date =@date";
            try
            {
                using (DBDataHelper helper = new DBDataHelper())
                {
                    dt = helper.GetDataTable(query, SQLTextType.Query, list_params);
                }
                if (int.Parse(dt.Rows[0][0].ToString()) > 0)
                    status = DayStatus.Holiday;
                else
                    status = DayStatus.Active;
            }
            catch (Exception)
            {

            }
        }
        return status;
    }
    #endregion

    #region Reports_Data
    public DailyAttendanceReportViewModel GetDataForReportEmployeeWise(int employeeId, DateTime date, TimeSpan relaxation)
    {
        DataTable dtEmployees;
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        TimeSpan duration = GetDurationOfEmployeeDateWise(employeeId, date);

        List<SqlParameter> list_params = new List<SqlParameter>()
                                        { new SqlParameter("@date", date), 
                                          new SqlParameter("@employeeId", employeeId) };

        MasterShifts objShift = GetShiftForEmployee(employeeId); //Getting Shift Active as per Employee
        ManageLeaves objManageLeaves = new ManageLeaves();

        TimeSpan ShortLeaveDuration = objShift.SHLDuration;
        TimeSpan HalfLeaveDuration = new TimeSpan(4, 0, 0); //Change According
        TimeSpan totalDuration = new DateTime(1, 1, 1, objShift.SecondHalfEnd.Hours, objShift.SecondHalfEnd.Minutes, objShift.SecondHalfEnd.Seconds) - new DateTime(1, 1, 1, objShift.FirstHalfStart.Hours, objShift.FirstHalfStart.Minutes, objShift.FirstHalfStart.Seconds);
        DayStatus dayStatus = GetStatusOfDayEmployeeWise(date, employeeId);
        DailyAttendanceReportViewModel objDailyAttendanceReportViewModel = new DailyAttendanceReportViewModel();
        int typeOfLeave;// For the type of leave

        #region Generate Data
        try
        {
            using (DBDataHelper helper = new DBDataHelper())
            {
                dtEmployees = helper.GetDataTable("spGetEmployeesForDailyAttendanceReportByEmployeeId", SQLTextType.Stored_Proc, list_params);

                foreach (DataRow row in dtEmployees.Rows)
                {
                    objDailyAttendanceReportViewModel.EmployeeId = Int32.Parse(row[1].ToString());
                    objDailyAttendanceReportViewModel.Name = row[0].ToString();
                    objDailyAttendanceReportViewModel.FirstHalfStartTime = objShift.FirstHalfStart.ToString();
                    objDailyAttendanceReportViewModel.FirstHalfEndTime = objShift.FirstHalfEnd.ToString();
                    objDailyAttendanceReportViewModel.SecondHalfStartTime = objShift.SecondHalfStart.ToString();
                    objDailyAttendanceReportViewModel.SecondHalfEndTime = objShift.SecondHalfEnd.ToString();
                    objDailyAttendanceReportViewModel.Relaxation = relaxation.ToString();
                    objDailyAttendanceReportViewModel.Date = date;
                    objDailyAttendanceReportViewModel.Duration = duration;
                    
                    #region If Present
                    if (row[2] != DBNull.Value) //Entry Time is Not  Null ---- Employee is Present
                    {
                        if (TimeSpan.Parse(row[2].ToString()) > (TimeSpan.Parse(objDailyAttendanceReportViewModel.FirstHalfEndTime) + relaxation))
                        {
                            objDailyAttendanceReportViewModel.LateByDuration = TimeSpan.Parse(row[2].ToString()) - TimeSpan.Parse(objDailyAttendanceReportViewModel.FirstHalfEndTime) + relaxation;
                        }
                        
                        objDailyAttendanceReportViewModel.InTime = row[2].ToString();
                        objDailyAttendanceReportViewModel.OutTime = row[3] == DBNull.Value ? objShift.SecondHalfEnd.ToString() : row[3].ToString(); //IfExitPunch is Null

                        if (row[3] == DBNull.Value)
                        {
                            if (dayStatus != DayStatus.WeeklyOff)
                                objDailyAttendanceReportViewModel.Status = BAS.Enums.Status.PresentWithNoOutPunch;//Exit Time is Null
                            else
                                objDailyAttendanceReportViewModel.Status = BAS.Enums.Status.WeeklyOffPresentWithNoOutPunch;
                        }
                        else
                        {

                            if (objDailyAttendanceReportViewModel._inTime.TimeOfDay >= relaxation + objShift.FirstHalfStart)// IF Late
                            {
                                if(duration+HalfLeaveDuration <= totalDuration)
                                {
                                    objManageLeaves.AssignLeave(employeeId, date, (int)BAS.Enums.LeaveTypes.HDL);
                                    objDailyAttendanceReportViewModel.Status = BAS.Enums.Status.OnHalfDayLeaveFirstHalf;
                                }
                                else
                                {
                                    objManageLeaves.AssignLeave(employeeId, date, (int)BAS.Enums.LeaveTypes.SHL);
                                    objDailyAttendanceReportViewModel.Status = BAS.Enums.Status.OnShortLeave;
                                }
                            }
                            else if (duration + HalfLeaveDuration < duration)// Second Half Leave
                            {
                                objManageLeaves.AssignLeave(employeeId, date, (int)BAS.Enums.LeaveTypes.HDL);
                                objDailyAttendanceReportViewModel.Status = BAS.Enums.Status.OnHalfDayLeaveSecondHalf;
                            }
                            else
                            {
                                if (dayStatus != DayStatus.WeeklyOff)
                                    objDailyAttendanceReportViewModel.Status = BAS.Enums.Status.Present;
                                else
                                    objDailyAttendanceReportViewModel.Status = BAS.Enums.Status.WeeklyOffPresent;
                            }
                        } //

                    }
                    #endregion
                    #region If Absent
                    else  //Entry Time is Null
                    {
                        objDailyAttendanceReportViewModel.InTime = "00:00:00.0000000";
                        objDailyAttendanceReportViewModel.OutTime = "00:00:00.0000000";
                        if (dayStatus == DayStatus.Holiday)
                        {
                            objDailyAttendanceReportViewModel.Status = Status.Holiday;
                        }
                        else if (dayStatus == DayStatus.WeeklyOff)
                        {
                            objDailyAttendanceReportViewModel.Status = Status.WeeklyOff;
                        }
                        else if (objManageLeaves.IsEmployeeOnLeave(objDailyAttendanceReportViewModel.EmployeeId, date, out typeOfLeave))
                        {
                            objDailyAttendanceReportViewModel.Status = (Status)typeOfLeave;
                        }
                        else
                        {
                            objDailyAttendanceReportViewModel.Status = Status.LeaveWithoutPay;
                        }
                    }

                    #endregion

                }

            }
        }
        catch (Exception)
        {

        }
        #endregion

        return objDailyAttendanceReportViewModel;
    }

    #endregion

    #region Reports
    
    public List<DailyAttendanceReportViewModel> GetDailyAttendanceDetailedReport(DateTime date, TimeSpan relaxation)
    {
        ManageEmployees objManageEmployees = new ManageEmployees();
        List<Employees> lstEmployees = objManageEmployees.GetAllEmployees();
        List<DailyAttendanceReportViewModel> lstDailyAttendanceReportViewModel = new List<DailyAttendanceReportViewModel>();
        foreach (Employees employee in lstEmployees)
        {
            DailyAttendanceReportViewModel objDailyAttendanceReportViewModel = GetDataForReportEmployeeWise(employee.Id, date, relaxation);
            objDailyAttendanceReportViewModel.DepartmentId = employee.DepartmentId;
            objDailyAttendanceReportViewModel.DepartmentName = employee.DepartmentName;
            objDailyAttendanceReportViewModel.Date = date;
            lstDailyAttendanceReportViewModel.Add(objDailyAttendanceReportViewModel);
        }
        return lstDailyAttendanceReportViewModel;
    }
    public List<DailyAttendanceReportViewModel> GetMonthlyAttendanceDetailedReport(int employeeId, DateTime startDate, DateTime endDate, TimeSpan relaxation, out MonthlyReportOfEmployee objMonthlyReportOfEmployee)// aspx file mai check kar lena ki startDate < endDate
    {
        List<DailyAttendanceReportViewModel> lstMonthlyAttendanceReportViewModel = new List<DailyAttendanceReportViewModel>();
        objMonthlyReportOfEmployee = new MonthlyReportOfEmployee();
        for (DateTime date = startDate; date <= endDate;date = date.AddDays(1))
        {
            DailyAttendanceReportViewModel objMonthlyAttendanceReportViewModel = new DailyAttendanceReportViewModel();
            objMonthlyAttendanceReportViewModel = GetDataForReportEmployeeWise(employeeId, date, relaxation);
            objMonthlyAttendanceReportViewModel.Date = date;
            lstMonthlyAttendanceReportViewModel.Add(objMonthlyAttendanceReportViewModel);
        }

        foreach (var item in lstMonthlyAttendanceReportViewModel)
        {
          objMonthlyReportOfEmployee.TotalDuration += item.Duration;
            DayStatus daystatus = GetStatusOfDay(item.Date);
            if (daystatus == DayStatus.Active)
            {
                if (item.Status == Status.Present || item.Status == Status.PresentWithNoOutPunch)
                {
                    objMonthlyReportOfEmployee.PresentDays++;
                }
                else
                {
                    objMonthlyReportOfEmployee.AbsentDays++;
                }
            }
            else if (daystatus == DayStatus.WeeklyOff)
            {
                if (item.Status == Status.Present)
                {
                    item.Status = Status.WeeklyOffPresent;
                    objMonthlyReportOfEmployee.PresentDays++;
                }
                else if (item.Status == Status.PresentWithNoOutPunch)
                {
                    item.Status = Status.WeeklyOffPresentWithNoOutPunch;
                    objMonthlyReportOfEmployee.PresentDays++;
                }
                else
                {
                    item.Status = Status.WeeklyOff;
                }
            }
            else //Holiday
            {
                objMonthlyReportOfEmployee.Holidays++;
                item.Status = Status.Holiday;
            }
        }
        return lstMonthlyAttendanceReportViewModel;
    }
    public List<DailyAttendanceReportViewModel> GetDailyAbsent(DateTime date, TimeSpan relaxation)
    {
        List<DailyAttendanceReportViewModel> lstDailyAttendanceReportViewModel = new List<DailyAttendanceReportViewModel>();
        lstDailyAttendanceReportViewModel = GetDailyAttendanceDetailedReport(date, relaxation).Where(x => x.Status == Status.LeaveWithoutPay).ToList();
        return lstDailyAttendanceReportViewModel;
    }
    public List<DailyAttendanceReportViewModel> GetDailyPresent(DateTime date, TimeSpan relaxation)
    {
        List<DailyAttendanceReportViewModel> lstDailyAttendanceReportViewModel = new List<DailyAttendanceReportViewModel>();
        lstDailyAttendanceReportViewModel = GetDailyAttendanceDetailedReport(date, relaxation).Where(x => x.Status == Status.Present).ToList();
        return lstDailyAttendanceReportViewModel;
    }
    public List<DailyAttendanceReportViewModel> GetDailyLateComers(DateTime date, TimeSpan relaxation)
    {
        List<DailyAttendanceReportViewModel> lstDailyAttendanceReportViewModel = new List<DailyAttendanceReportViewModel>();
        lstDailyAttendanceReportViewModel = GetDailyAttendanceDetailedReport(date, relaxation).Where(x => x._inTime >= x._firstHalfStartTime + relaxation).ToList();
        return lstDailyAttendanceReportViewModel;
    }
    public List<DailyAttendanceReportViewModel> GetMonthlyLateComers(DateTime startDate, DateTime endDate, TimeSpan relaxation)
    {
        List<DailyAttendanceReportViewModel> lstDailyAttendanceReportViewModel = new List<DailyAttendanceReportViewModel>();
        for (DateTime date = startDate; date <= endDate;date = date.AddDays(1))
        {
            List<DailyAttendanceReportViewModel> objDailyAttendanceReportViewModel = GetDailyLateComers(date, relaxation);
           lstDailyAttendanceReportViewModel = lstDailyAttendanceReportViewModel.Concat(objDailyAttendanceReportViewModel).ToList();
        }
        return lstDailyAttendanceReportViewModel;
    }
    public List<DailyAttendanceReportViewModel> GetDailyAttendanceDetailedReportDepartmentWise(int departmentId,DateTime date, TimeSpan relaxation)
    {
        List<DailyAttendanceReportViewModel> lstDailyAttendanceReportViewModel = new List<DailyAttendanceReportViewModel>();
        lstDailyAttendanceReportViewModel = GetDailyAttendanceDetailedReport(date, relaxation).Where(x => x.DepartmentId == departmentId).ToList();
        return lstDailyAttendanceReportViewModel;
    }
    #endregion
    
    #endregion

    // Leave Forwarding i.e. to next session 
}