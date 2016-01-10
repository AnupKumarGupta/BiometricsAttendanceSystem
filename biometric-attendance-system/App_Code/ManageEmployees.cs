using DALHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ManageEmployees
/// </summary>
public class ManageEmployees
{
    public void CreateEmployee(Employees objEmployee)
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        List<SqlParameter> lstMasterEmployeeDetail = new List<SqlParameter>();
        lstMasterEmployeeDetail.Add(new SqlParameter("@facultyId", objEmployee.Id));
        lstMasterEmployeeDetail.Add(new SqlParameter("@name", objEmployee.Name));
        lstMasterEmployeeDetail.Add(new SqlParameter("@dateOfBirth", objEmployee.DateOfBirth));
        lstMasterEmployeeDetail.Add(new SqlParameter("@joiningDate", objEmployee.JoiningDate));
        lstMasterEmployeeDetail.Add(new SqlParameter("@gender", objEmployee.Gender));
        lstMasterEmployeeDetail.Add(new SqlParameter("@createdAt", objEmployee.CreatedOn));
        lstMasterEmployeeDetail.Add(new SqlParameter("@isDeleted", false));
        DataTable dt = new DataTable();
        DataSet ds;
        int EmployeeId;
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            ds = objDDBDataHelper.GetDataSet("spCreateEmployee", SQLTextType.Stored_Proc, lstMasterEmployeeDetail);
            EmployeeId = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        }
        List<SqlParameter> lstEmployeeDetail = new List<SqlParameter>();
        lstEmployeeDetail.Add(new SqlParameter("@employeeId", EmployeeId));
        lstEmployeeDetail.Add(new SqlParameter("@imagePath", objEmployee.ImagePath));
        lstEmployeeDetail.Add(new SqlParameter("@password", objEmployee.Password));
        lstEmployeeDetail.Add(new SqlParameter("@roleId", objEmployee.RoleId));
        lstEmployeeDetail.Add(new SqlParameter("@departmentId", objEmployee.DepartmentId));
        lstEmployeeDetail.Add(new SqlParameter("@contactNumber", objEmployee.ContactNumber));
        lstEmployeeDetail.Add(new SqlParameter("@createdAt", objEmployee.CreatedOn));
        lstEmployeeDetail.Add(new SqlParameter("@updatedAt", objEmployee.UpdatedOn));
        lstEmployeeDetail.Add(new SqlParameter("@isDeleted", false));
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            objDDBDataHelper.ExecSQL("spCreateEmployeeTransc", SQLTextType.Stored_Proc, lstEmployeeDetail);
        }

    }
    public bool UpdateEmployee(Employees objEmployee)
    {
        List<SqlParameter> lstEmployeeDetail = new List<SqlParameter>();
        lstEmployeeDetail.Add(new SqlParameter("@employeeId", objEmployee.Id));
        lstEmployeeDetail.Add(new SqlParameter("@gender", objEmployee.Gender));
        lstEmployeeDetail.Add(new SqlParameter("@dateOfBirth", objEmployee.DateOfBirth));
        lstEmployeeDetail.Add(new SqlParameter("@joiningDate", objEmployee.JoiningDate));
        lstEmployeeDetail.Add(new SqlParameter("@isDeleted", false));
        lstEmployeeDetail.Add(new SqlParameter("@updatedOn", DateTime.Now));
        lstEmployeeDetail.Add(new SqlParameter("@password", objEmployee.Password));
        lstEmployeeDetail.Add(new SqlParameter("@roleId", objEmployee.RoleId));
        lstEmployeeDetail.Add(new SqlParameter("@departmentId", objEmployee.DepartmentId));
        lstEmployeeDetail.Add(new SqlParameter("@contactNumber", objEmployee.ContactNumber));
        DataTable dt = new DataTable();
        try
        {
            using (DBDataHelper objDDBDataHelper = new DBDataHelper())
            {
                objDDBDataHelper.ExecSQL("spUpdateEmployeeByEmployeeId", SQLTextType.Stored_Proc, lstEmployeeDetail);

            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    public bool DeleteEmployee(long employeeId)
    {
        List<SqlParameter> lstEmployeeDetail = new List<SqlParameter>();
        lstEmployeeDetail.Add(new SqlParameter("@employeeId", employeeId));
        DataTable dt = new DataTable();
        try
        {
            using (DBDataHelper objDDBDataHelper = new DBDataHelper())
            {
                objDDBDataHelper.ExecSQL("spDeleteEmployee", SQLTextType.Stored_Proc, lstEmployeeDetail);
            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    public List<Employees> GetAllEmployees()
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DataSet ds;
        int i = 0;
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            ds = objDDBDataHelper.GetDataSet("spGetAllEmployees", SQLTextType.Stored_Proc);
            List<Employees> lstEmployee = new List<Employees>();
            foreach (DataRow rows in ds.Tables[0].Rows)
            {
                Employees objEmployee = new Employees();
                objEmployee.Id = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
                objEmployee.Name = ds.Tables[0].Rows[i][1].ToString();
                objEmployee.Gender = ds.Tables[0].Rows[i][2] == DBNull.Value ? "NULL" : ds.Tables[0].Rows[i][2].ToString();
                objEmployee.DateOfBirth = ds.Tables[0].Rows[i][3] == DBNull.Value ? new DateTime() : Convert.ToDateTime(ds.Tables[0].Rows[i][3]);
                objEmployee.JoiningDate = ds.Tables[0].Rows[i][4] == DBNull.Value ? new DateTime() : Convert.ToDateTime(ds.Tables[0].Rows[i][4]);
                objEmployee.ImagePath = ds.Tables[0].Rows[i][5] == DBNull.Value ? "NULL" : ds.Tables[0].Rows[i][5].ToString();
                objEmployee.ContactNumber = ds.Tables[0].Rows[i][6] == DBNull.Value ? new Int64() : Convert.ToInt64(ds.Tables[0].Rows[i][6]);
                objEmployee.Password = ds.Tables[0].Rows[i][7] == DBNull.Value ? "NULL" : ds.Tables[0].Rows[i][7].ToString();
                objEmployee.DepartmentId = ds.Tables[0].Rows[i][8] == DBNull.Value ? new Int32() : Convert.ToInt32(ds.Tables[0].Rows[i][8]);
                objEmployee.DepartmentName = ds.Tables[0].Rows[i][9] == DBNull.Value ? "NULL" : ds.Tables[0].Rows[i][9].ToString();
                objEmployee.RoleId = ds.Tables[0].Rows[i][10] == DBNull.Value ? new Int32() : Convert.ToInt32(ds.Tables[0].Rows[i][10]); ;
                objEmployee.RoleName = ds.Tables[0].Rows[i][11] == DBNull.Value ? "NULL" : ds.Tables[0].Rows[i][11].ToString();
                lstEmployee.Add(objEmployee);
                i++;
            }
            return lstEmployee;
        }
    }
    public Employees GetEmployeeById(long Id)
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DBDataHelper helper = new DBDataHelper();
        List<SqlParameter> lstEmployeeDetail = new List<SqlParameter>();
        lstEmployeeDetail.Add(new SqlParameter("@employeeId", Id));
        DataSet ds;
        int i = 0;
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            ds = objDDBDataHelper.GetDataSet("spGetEmployeeById", SQLTextType.Stored_Proc, lstEmployeeDetail);
            Employees objEmployee = new Employees();
            objEmployee.Id = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
            objEmployee.Name = ds.Tables[0].Rows[i][1].ToString();
            objEmployee.Gender = ds.Tables[0].Rows[i][2] == DBNull.Value ? "NULL" : ds.Tables[0].Rows[i][2].ToString();
            objEmployee.DateOfBirth = ds.Tables[0].Rows[i][3] == DBNull.Value ? new DateTime() : Convert.ToDateTime(ds.Tables[0].Rows[i][3]);
            objEmployee.JoiningDate = ds.Tables[0].Rows[i][4] == DBNull.Value ? new DateTime() : Convert.ToDateTime(ds.Tables[0].Rows[i][4]);
            objEmployee.ImagePath = ds.Tables[0].Rows[i][5] == DBNull.Value ? "NULL" : ds.Tables[0].Rows[i][5].ToString();
            objEmployee.ContactNumber = ds.Tables[0].Rows[i][6] == DBNull.Value ? new Int64() : Convert.ToInt64(ds.Tables[0].Rows[i][6]);
            objEmployee.Password = ds.Tables[0].Rows[i][7] == DBNull.Value ? "NULL" : ds.Tables[0].Rows[i][7].ToString();
            objEmployee.DepartmentId = ds.Tables[0].Rows[i][8] == DBNull.Value ? new Int32() : Convert.ToInt32(ds.Tables[0].Rows[i][8]);
            objEmployee.DepartmentName = ds.Tables[0].Rows[i][9] == DBNull.Value ? "NULL" : ds.Tables[0].Rows[i][9].ToString();
            objEmployee.RoleId = ds.Tables[0].Rows[i][10] == DBNull.Value ? new Int32() : Convert.ToInt32(ds.Tables[0].Rows[i][10]); ;
            objEmployee.RoleName = ds.Tables[0].Rows[i][11] == DBNull.Value ? "NULL" : ds.Tables[0].Rows[i][11].ToString();
            return objEmployee;
        }
    }
    public List<Employees> GetEmployeesByDepartment(int departmentId)
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DataSet ds;
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            List<SqlParameter> lstEmployeeDetail = new List<SqlParameter>();
            lstEmployeeDetail.Add(new SqlParameter("@departmentId", departmentId));
            ds = objDDBDataHelper.GetDataSet("spGetAllEmployeesByDepartment", SQLTextType.Stored_Proc, lstEmployeeDetail);
            List<Employees> lstEmployee = new List<Employees>();
            int i = 0;
            foreach (DataRow rows in ds.Tables[0].Rows)
            {
                Employees objEmployee = new Employees();
                objEmployee.Id = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
                objEmployee.Name = ds.Tables[0].Rows[i][1].ToString();
                objEmployee.RoleId = Convert.ToInt32(ds.Tables[0].Rows[i][2]);
                objEmployee.RoleName = ds.Tables[0].Rows[i][3].ToString();
                lstEmployee.Add(objEmployee);
                i++;
            }
            return lstEmployee;
        }
    }
}