using DALHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BAS;

/// <summary>
/// Summary description for ManageAttendance
/// </summary>
public class ManageAttendance
{
    #region Old Code
    //public int GetEntryStatus(Attendance objAttendance)
    //{
    //    DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
    //    DBDataHelper helper = new DBDataHelper();
    //    List<SqlParameter> lstAttendanceDetail = new List<SqlParameter>();
    //    lstAttendanceDetail.Add(new SqlParameter("@employeeId", objAttendance.EmployeeId));
    //    lstAttendanceDetail.Add(new SqlParameter("@dateTime", objAttendance.Date));
    //    DataTable dt = new DataTable();
    //    DataSet ds;
    //    using (DBDataHelper objDDBDataHelper = new DBDataHelper())
    //    {
    //       ds = objDDBDataHelper.GetDataSet("spGetAttendanceStatus", SQLTextType.Stored_Proc, lstAttendanceDetail);
    //        Employees objEmployee = new Employees();
    //        List<Employees> lstEmployee = new List<Employees>();
    //        return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
    //    }
    //}

    //public int GetExitStatus(Attendance objAttendance)
    //{
    //    DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
    //    DBDataHelper helper = new DBDataHelper();
    //    List<SqlParameter> lstAttendanceDetail = new List<SqlParameter>();
    //    lstAttendanceDetail.Add(new SqlParameter("@employeeId", objAttendance.EmployeeId));
    //    lstAttendanceDetail.Add(new SqlParameter("@dateTime", objAttendance.Date));
    //    DataSet ds;
    //    using (DBDataHelper objDDBDataHelper = new DBDataHelper())
    //    {
    //        ds = objDDBDataHelper.GetDataSet("spGetExitStatus", SQLTextType.Stored_Proc, lstAttendanceDetail);
    //    }
    //    var x = ds.Tables[0].Rows[0][0].ToString();
    //    return (String.IsNullOrEmpty(x)) ? 0 : 1;
    //}

    //public bool EntryOrExitEmployee(Attendance objAttendance, out int status)
    //{
    //    DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
    //    List<SqlParameter> lstAttendanceDetail = new List<SqlParameter>();
    //    lstAttendanceDetail.Add(new SqlParameter("@employeeId", objAttendance.EmployeeId));
    //    lstAttendanceDetail.Add(new SqlParameter("@dateTime", objAttendance.Date));
    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
    //        {
    //            ds = objDDBDataHelper.GetDataSet("spAssignAttendance", SQLTextType.Stored_Proc, lstAttendanceDetail);
    //        }
    //        status = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
    //        return true;
    //    }
    //    catch(Exception ex)
    //    {
    //        status = 0;
    //        return false;
    //    }
    //}

    //public List<Employees> GetEmployeesPresentDateWise(DateTime dateTime)
    //{
    //    DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
    //    List<Employees> lstEmployees = new List<Employees>();
    //    List<SqlParameter> lstAttendanceDetail = new List<SqlParameter>();
    //    lstAttendanceDetail.Add(new SqlParameter("@date", dateTime));
    //    int i = 0;
    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
    //        {
    //            ds = objDDBDataHelper.GetDataSet("spGetEmployeesPresentDateWise", SQLTextType.Stored_Proc, lstAttendanceDetail);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        return lstEmployees;
    //    }
    //    foreach (DataRow rows in ds.Tables[0].Rows)
    //    {
    //        Employees objEmployees = new Employees();
    //        objEmployees.Id = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
    //        objEmployees.FirstName = ds.Tables[0].Rows[i][1].ToString();
    //        objEmployees.MiddleName = ds.Tables[0].Rows[i][2].ToString();
    //        objEmployees.LastName = ds.Tables[0].Rows[i][3].ToString();
    //        lstEmployees.Add(objEmployees);
    //        i++;
    //    }
    //    return lstEmployees;
    //} 
    #endregion

    #region New Code
    public void GetDataFromDevice()
    {
        new Connection().GetData();
    }
    #endregion
}