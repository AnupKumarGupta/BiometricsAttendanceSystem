using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DALHelper;

public class MasterEntries
{
    #region ManageDepartment

    /// <summary>
    /// Adds a new Department
    /// </summary>
    /// <param name="Department">String value for Department Name</param>
    /// <returns>True if Department is added successfully</returns>
    public bool AddDepartment(string Department)
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        List<SqlParameter> lstDepartment = new List<SqlParameter>();
        lstDepartment.Add(new SqlParameter("@name", Department));
        lstDepartment.Add(new SqlParameter("@createdOn", DateTime.Now));
        lstDepartment.Add(new SqlParameter("@updatedOn", DateTime.Now));
        DataTable dt = new DataTable();
        try
        {
            using (DBDataHelper objDDBDataHelper = new DBDataHelper())
            {
                objDDBDataHelper.ExecSQL("spCreateDepartment", SQLTextType.Stored_Proc, lstDepartment);
            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    /// <summary>
    /// Gives All Departments
    /// </summary>
    /// <returns> List of Department Objects</returns>
    public List<Departments> GetAllDepartments()
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DataTable dt = new DataTable();
        DataSet ds;
        int i = 0;
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            ds = objDDBDataHelper.GetDataSet("spGetAllDepartments", SQLTextType.Stored_Proc);
            List<Departments> lstDepartment = new List<Departments>();

            foreach (DataRow rows in ds.Tables[0].Rows)
            {
                Departments objDepartment = new Departments();
                objDepartment.Id = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
                objDepartment.Name = (ds.Tables[0].Rows[i][1]).ToString();
                lstDepartment.Add(objDepartment);
                i++;
            }
            return lstDepartment;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="departmentId"></param>
    /// <returns></returns>
    public string GetDepartmentById(int departmentId)
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        List<SqlParameter> lstDepartment = new List<SqlParameter>();
        lstDepartment.Add(new SqlParameter("@departmentId", departmentId));
        DataTable dt = new DataTable();
        DataSet ds;
        string department;
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            ds = objDDBDataHelper.GetDataSet("spGetDepartmentById", SQLTextType.Stored_Proc, lstDepartment);
            department = ds.Tables[0].Rows[0][0].ToString();
        }
        return department;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="departmentId"></param>
    /// <returns></returns>
    public bool UpdateDepartment(int departmentId, string Department)//Changes Remaining
    {
        List<SqlParameter> lstDepartment = new List<SqlParameter>();
        lstDepartment.Add(new SqlParameter("@name", Department));
        lstDepartment.Add(new SqlParameter("@departmentId", departmentId));
        lstDepartment.Add(new SqlParameter("@updatedAt", DateTime.Now));
        DataTable dt = new DataTable();
        try
        {
            using (DBDataHelper objDDBDataHelper = new DBDataHelper())
            {
                objDDBDataHelper.ExecSQL("spUpdateDepartment", SQLTextType.Stored_Proc, lstDepartment);

            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    #endregion

    #region ManageLeaves

    /// <summary>
    /// Add a new type of Leave
    /// </summary>
    /// <param name="leaveName">String value for name of leave</param>
    /// <param name="masterLeaveType">Master leave type (Full day, Halfday,etc)</param>
    /// <returns>True if entry is successful</returns>
    public bool AddTypeOfLeave(string leaveName)
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        List<SqlParameter> lstLeave = new List<SqlParameter>();
        lstLeave.Add(new SqlParameter("@name", leaveName));
        lstLeave.Add(new SqlParameter("@createdOn", DateTime.Now));
        lstLeave.Add(new SqlParameter("@updatedOn", DateTime.Now));
        lstLeave.Add(new SqlParameter("@isDeleted", false));
        DataTable dt = new DataTable();
        try
        {
            using (DBDataHelper objDDBDataHelper = new DBDataHelper())
            {
                objDDBDataHelper.ExecSQL("spCreateTypeOfLeave", SQLTextType.Stored_Proc, lstLeave);
            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }

    /// <summary>
    /// Returns all type of leaves
    /// </summary>
    /// <returns>List of types of leaves(objects)</returns>
    public List<Leaves> GetAllTypeOfLeaves()
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DataTable dt = new DataTable();
        DataSet ds;
        int i = 0;
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            ds = objDDBDataHelper.GetDataSet("spGetAllTypeOfLeaves ", SQLTextType.Stored_Proc);
            List<Leaves> lstLeaveType = new List<Leaves>();
            foreach (DataRow rows in ds.Tables[0].Rows)
            {
                Leaves objLeaves = new Leaves();
                objLeaves.Id = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
                objLeaves.LeaveName = (ds.Tables[0].Rows[i][1]).ToString();
                lstLeaveType.Add(objLeaves);
                i++;
            }
            return lstLeaveType;
        }
    }
    public bool GetLeavesById(int leaveId, out Leaves objLeaves)
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        List<SqlParameter> lstLeave = new List<SqlParameter>();
        lstLeave.Add(new SqlParameter("@leaveId", leaveId));
        DataTable dt = new DataTable();
        DataSet ds;
        int i = 0;
        Leaves objLeaves1 = new Leaves();
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            ds = objDDBDataHelper.GetDataSet("spGetTypeOfLeaveById ", SQLTextType.Stored_Proc, lstLeave);
            List<Leaves> lstLeaveType = new List<Leaves>();
            foreach (DataRow rows in ds.Tables[0].Rows)
            {
                objLeaves1.Id = leaveId;
                objLeaves1.LeaveName = (ds.Tables[0].Rows[i][0]).ToString();
                lstLeaveType.Add(objLeaves1);
                i++;
            }
            objLeaves = objLeaves1;
            return true;
        }
    }

    public bool UpdateLeave(int leaveId, string leaveName)
    {
        List<SqlParameter> lstLeave = new List<SqlParameter>();
        lstLeave.Add(new SqlParameter("@leaveId", leaveId));
        lstLeave.Add(new SqlParameter("@name", leaveName));
        lstLeave.Add(new SqlParameter("@updatedAt", DateTime.Now));
        DataTable dt = new DataTable();
        try
        {
            using (DBDataHelper objDDBDataHelper = new DBDataHelper())
            {
                objDDBDataHelper.ExecSQL("spUpdateLeave", SQLTextType.Stored_Proc, lstLeave);

            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool LeaveAssignedByRole(int leaveId, int roleId, int noOfLeaves, bool isPromoted, int limit)
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DBDataHelper helper = new DBDataHelper();
        List<SqlParameter> lstLeaveAssignedByRole = new List<SqlParameter>();
        lstLeaveAssignedByRole.Add(new SqlParameter("@leaveId", leaveId));
        lstLeaveAssignedByRole.Add(new SqlParameter("@roleId", roleId));
        lstLeaveAssignedByRole.Add(new SqlParameter("@noOfLeaves", noOfLeaves));
        lstLeaveAssignedByRole.Add(new SqlParameter("@isPromoted", isPromoted));
        lstLeaveAssignedByRole.Add(new SqlParameter("@limit", limit));
        DataTable dt = new DataTable();
        try
        {
            using (DBDataHelper objDDBDataHelper = new DBDataHelper())
            {
                objDDBDataHelper.ExecSQL("spAssignLeaveByRole", SQLTextType.Stored_Proc, lstLeaveAssignedByRole);
            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public int Count(int roleId, int leaveId)
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DataTable dt = new DataTable();
        List<SqlParameter> lstLeaveAssignedByRole = new List<SqlParameter>();
        lstLeaveAssignedByRole.Add(new SqlParameter("@leaveId", leaveId));
        lstLeaveAssignedByRole.Add(new SqlParameter("@roleId", roleId));
        DataSet ds;
        int i;
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            ds = objDDBDataHelper.GetDataSet("IsSingle", SQLTextType.Stored_Proc, lstLeaveAssignedByRole);
            i = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        }
        return i;
    }

    public bool GetLeavesAssignedByRoleById(int id, out LeaveAssignedByRole objLeaves)
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        List<SqlParameter> lstparameter = new List<SqlParameter>();
        lstparameter.Add(new SqlParameter("@id", id));
        DataTable dt = new DataTable();
        DataSet ds;
        int i = 0;
        LeaveAssignedByRole objLeaves1 = new LeaveAssignedByRole();
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            ds = objDDBDataHelper.GetDataSet("spGetLeaveAssignedByRoleById", SQLTextType.Stored_Proc, lstparameter);
            List<LeaveAssignedByRole> lstLeaveType = new List<LeaveAssignedByRole>();
            foreach (DataRow rows in ds.Tables[0].Rows)
            {
                objLeaves1.Id = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
                objLeaves1.RoleId = Convert.ToInt32(ds.Tables[0].Rows[i][1]);
                objLeaves1.LeaveTypeId = Convert.ToInt32(ds.Tables[0].Rows[i][2]);
                objLeaves1.NoOfLeaves = Convert.ToInt32(ds.Tables[0].Rows[i][3]);
                objLeaves1.IsPromoted = Convert.ToBoolean(ds.Tables[0].Rows[i][4]);
                objLeaves1.Limit = Convert.ToInt32(ds.Tables[0].Rows[i][5]);
                objLeaves1.RoleName = (ds.Tables[0].Rows[i][6]).ToString();
                objLeaves1.LeaveName = (ds.Tables[0].Rows[i][7]).ToString();
                lstLeaveType.Add(objLeaves1);
                i++;
            }
            objLeaves = objLeaves1;
            return true;
        }
    }
    public bool UpdateLeavesAssignedByRole(int id, int limit, int noOfLeaves, bool isPromoted)
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        List<SqlParameter> lstparameter = new List<SqlParameter>();
        lstparameter.Add(new SqlParameter("@id", id));
        lstparameter.Add(new SqlParameter("@limit", limit));
        lstparameter.Add(new SqlParameter("@noOfLeaves", noOfLeaves));
        lstparameter.Add(new SqlParameter("@isPromoted", isPromoted));
        DataTable dt = new DataTable();
        DataSet ds;
        int i = 0;
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            ds = objDDBDataHelper.GetDataSet("spUpdateLeavesAssignedByRole", SQLTextType.Stored_Proc, lstparameter);
        }
        return true;
    }

    public List<LeaveAssignedByRole> GetAllTypeOfLeavesAssignedByRole()
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DataTable dt = new DataTable();
        DataSet ds;
        int i = 0;
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            ds = objDDBDataHelper.GetDataSet("spGetAllTypeOfLeavesAssignedByRole", SQLTextType.Stored_Proc);
            List<LeaveAssignedByRole> lstLeaveType = new List<LeaveAssignedByRole>();
            foreach (DataRow rows in ds.Tables[0].Rows)
            {
                LeaveAssignedByRole objLeaves = new LeaveAssignedByRole();
                objLeaves.Id = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
                objLeaves.RoleId = Convert.ToInt32(ds.Tables[0].Rows[i][1]);
                objLeaves.LeaveTypeId = Convert.ToInt32(ds.Tables[0].Rows[i][2]);
                objLeaves.NoOfLeaves = Convert.ToInt32(ds.Tables[0].Rows[i][3]);
                objLeaves.IsPromoted = Convert.ToBoolean(ds.Tables[0].Rows[i][4]);
                objLeaves.Limit = Convert.ToInt32(ds.Tables[0].Rows[i][5]);
                objLeaves.RoleName = (ds.Tables[0].Rows[i][6]).ToString();
                objLeaves.LeaveName = (ds.Tables[0].Rows[i][7]).ToString();
                lstLeaveType.Add(objLeaves);
                i++;
            }
            return lstLeaveType;
        }
    }


    #endregion

    #region ManageRoles

    /// <summary>
    /// Add a new type of Role
    /// </summary>
    /// <param name="Role">String Value for name of Role</param>
    /// <returns>True if entry is successfull else False</returns>
    public bool AddRole(string Role)
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        List<SqlParameter> lstRole = new List<SqlParameter>();
        lstRole.Add(new SqlParameter("@name", Role));
        lstRole.Add(new SqlParameter("@createdOn", DateTime.Now));
        lstRole.Add(new SqlParameter("@updatedOn", DateTime.Now));
        lstRole.Add(new SqlParameter("@isDeleted", false));

        DataTable dt = new DataTable();
        try
        {
            using (DBDataHelper objDDBDataHelper = new DBDataHelper())
            {
                objDDBDataHelper.ExecSQL("spAddRole", SQLTextType.Stored_Proc, lstRole);

            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="departmentId"></param>
    /// <returns></returns>
    public string GetRoleById(int roleId)
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        List<SqlParameter> lstRole = new List<SqlParameter>();
        lstRole.Add(new SqlParameter("@roleId", roleId));
        DataTable dt = new DataTable();
        DataSet ds;
        string role;
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            ds = objDDBDataHelper.GetDataSet("spGetRoleById", SQLTextType.Stored_Proc, lstRole);
            role = ds.Tables[0].Rows[0][0].ToString();
        }
        return role;
    }

    /// <summary>
    /// Returns all types of Roles
    /// </summary>
    /// <returns>List of Role objects</returns>
    public List<Role> GetAllRoles()
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DataTable dt = new DataTable();
        DataSet ds;
        int i = 0;
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            ds = objDDBDataHelper.GetDataSet("spGetAllRoles", SQLTextType.Stored_Proc);
            List<Role> lstRole = new List<Role>();

            foreach (DataRow rows in ds.Tables[0].Rows)
            {
                Role objRole = new Role();
                objRole.Id = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
                objRole.Name = (ds.Tables[0].Rows[i][1]).ToString();
                lstRole.Add(objRole);
                i++;
            }
            return lstRole;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="roleId"></param>
    /// <returns></returns>
    public bool UpdateRole(int roleId, string Role) // To be Edited
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        List<SqlParameter> lstRole = new List<SqlParameter>();
        lstRole.Add(new SqlParameter("@roleId", roleId));
        lstRole.Add(new SqlParameter("@name", Role));
        lstRole.Add(new SqlParameter("@updatedAt", DateTime.Now));
        DataTable dt = new DataTable();
        DataSet ds;
        try
        {
            using (DBDataHelper objDDBDataHelper = new DBDataHelper())
            {
                ds = objDDBDataHelper.GetDataSet("spUpdateRole", SQLTextType.Stored_Proc, lstRole);
            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    #endregion

    #region ManageShifts

    /// <summary>
    /// Add a new Shift 
    /// </summary>
    /// <param name="shift">Shift type object</param>
    /// <returns>True if entry is successfull else False</returns>
    public bool AddShift(Shifts shift)
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        List<SqlParameter> lstShift = new List<SqlParameter>();
        lstShift.Add(new SqlParameter("@firstHalfStart", shift.FirstHalfStart));
        lstShift.Add(new SqlParameter("@firstHalfEnd", shift.FirstHalfEnd));
        lstShift.Add(new SqlParameter("@secondHalfStart", shift.SecondHalfStart));
        lstShift.Add(new SqlParameter("@secondHalfEnd", shift.SecondHalfEnd));
        lstShift.Add(new SqlParameter("@isActive", false));
        lstShift.Add(new SqlParameter("@createdOn", DateTime.Now));
        lstShift.Add(new SqlParameter("@updatedOn", DateTime.Now));
        lstShift.Add(new SqlParameter("@isDeleted", false));

        DataTable dt = new DataTable();
        try
        {
            using (DBDataHelper objDDBDataHelper = new DBDataHelper())
            {
                objDDBDataHelper.ExecSQL("spAddShift", SQLTextType.Stored_Proc, lstShift);

            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }

    /// <summary>
    /// Get all shifts
    /// </summary>
    /// <returns>List of Shifts object</returns>
    public List<Shifts> GetAllShifts()
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DataTable dt = new DataTable();
        DataSet ds;
        int i = 0;
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            ds = objDDBDataHelper.GetDataSet("spGetAllShifts", SQLTextType.Stored_Proc);
            List<Shifts> lstShifts = new List<Shifts>();

            foreach (DataRow rows in ds.Tables[0].Rows)
            {
                Shifts objShifts = new Shifts();
                objShifts.Id = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
                objShifts.FirstHalfStart = TimeSpan.Parse(ds.Tables[0].Rows[i][1].ToString());
                objShifts.FirstHalfEnd = TimeSpan.Parse(ds.Tables[0].Rows[i][2].ToString());
                objShifts.SecondHalfStart = TimeSpan.Parse(ds.Tables[0].Rows[i][3].ToString());
                objShifts.SecondHalfEnd = TimeSpan.Parse(ds.Tables[0].Rows[i][4].ToString());
                objShifts.IsActive = Convert.ToBoolean(ds.Tables[0].Rows[i][5]);
                lstShifts.Add(objShifts);
                i++;
            }
            return lstShifts;
        }
    }

    #endregion

    #region ManageDuration

    /// <summary>
    /// Add a new duration entry
    /// </summary>
    /// <param name="duration">TimeSpan value for duration</param>
    /// <returns>True if entry is successfull, else False</returns>
    /// 
    public bool AddDuration(TimeSpan duration, int leaveId)
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DBDataHelper helper = new DBDataHelper();
        List<SqlParameter> lstDuration = new List<SqlParameter>();
        lstDuration.Add(new SqlParameter("@duration", duration));
        lstDuration.Add(new SqlParameter("@leaveId", leaveId));
        lstDuration.Add(new SqlParameter("@createdOn", DateTime.Now));
        lstDuration.Add(new SqlParameter("@updatedOn", DateTime.Now));
        lstDuration.Add(new SqlParameter("@isActive", false));
        lstDuration.Add(new SqlParameter("@isDeleted", false));
        DataTable dt = new DataTable();
        try
        {
            using (DBDataHelper objDDBDataHelper = new DBDataHelper())
            {
                objDDBDataHelper.ExecSQL("spAddDuration", SQLTextType.Stored_Proc, lstDuration);
            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }
    /// <summary>
    /// Get all  Durations
    /// </summary>
    /// <returns>List of Duration objects</returns>
    public List<Duration> GetAllDurations()
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DataTable dt = new DataTable();
        DataSet ds;
        int i = 0;
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            ds = objDDBDataHelper.GetDataSet("spGetAllDurations", SQLTextType.Stored_Proc);
            List<Duration> lstDuration = new List<Duration>();
            Leaves objLeaves = new Leaves();
            foreach (DataRow rows in ds.Tables[0].Rows)
            {
                Duration objDuration = new Duration();
                objDuration.Id = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
                objDuration.leaveId = Convert.ToInt32(ds.Tables[0].Rows[i][1]);
                GetLeavesById(objDuration.leaveId, out objLeaves);
                objDuration.leaveName = objLeaves.LeaveName;
                objDuration.duration = (TimeSpan)(ds.Tables[0].Rows[i][2]);
                lstDuration.Add(objDuration);
                i++;
            }
            return lstDuration;
        }
    }

    public TimeSpan GetDurationById(int Id)
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        DataTable dt = new DataTable();
        DataSet ds;
        List<SqlParameter> lstDurations = new List<SqlParameter>();
        lstDurations.Add(new SqlParameter("@id", Id));
        int i = 0;
        TimeSpan duration = TimeSpan.Parse("00:00");
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            ds = objDDBDataHelper.GetDataSet("spGetDurationById", SQLTextType.Stored_Proc, lstDurations);
            List<Duration> lstDuration = new List<Duration>();
            Leaves objLeaves = new Leaves();

            foreach (DataRow rows in ds.Tables[0].Rows)
            {
                duration = (TimeSpan)(ds.Tables[0].Rows[i][2]);
            }
        }
        return duration;
    }
    #endregion

    public List<LeaveAssignedPerSession> ShowLeaveDetailsOfEmployeeByDepartment(int departmentId)
    {
        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        List<SqlParameter> lstDetails = new List<SqlParameter>();
        lstDetails.Add(new SqlParameter("@departmentId", departmentId));
        DataTable dt = new DataTable();
        DataSet ds;
        int i = 0;
        using (DBDataHelper objDDBDataHelper = new DBDataHelper())
        {
            ds = objDDBDataHelper.GetDataSet("spAssignLeaveByFaculty", SQLTextType.Stored_Proc, lstDetails);

            List<LeaveAssignedPerSession> lstLeaveAssignedPerSession = new List<LeaveAssignedPerSession>();
            foreach (DataRow rows in ds.Tables[0].Rows)
            {
                LeaveAssignedPerSession objLeaveAssignedPerSession = new LeaveAssignedPerSession();
                objLeaveAssignedPerSession.EmployeeName = (ds.Tables[0].Rows[i][0]).ToString();
                objLeaveAssignedPerSession.leaveType = Convert.ToInt32(ds.Tables[0].Rows[i][1]);
                objLeaveAssignedPerSession.leaveCount = Convert.ToInt32(ds.Tables[0].Rows[i][2]);
                lstLeaveAssignedPerSession.Add(objLeaveAssignedPerSession);
                i++;
            }
            return lstLeaveAssignedPerSession;
        }
    }

    //  To Do
    //  =====
    //  Toggle IsActive 
    //  IsDeleted
    //  Update function for all Domains
    //    public void GetLeavesDueOfEmployee(int employeeId, DateTime startDate)
    //    {
    //        DataTable dtAssignedLeaves;
    //        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
    //        List<LeavesCount> lstLeavesAssigned = new List<LeavesCount>();


    //        using (DBDataHelper helper = new DBDataHelper())
    //        {
    //            List<SqlParameter> list_params_Assigned = new List<SqlParameter>() { new SqlParameter("@employeeId", employeeId), new SqlParameter("@session", startDate) };
    //            dtAssignedLeaves = helper.GetDataTable("spGetLeavesAssignedToEmployeeSessionWise", SQLTextType.Stored_Proc, list_params_Assigned);
    //            foreach (DataRow row in dtAssignedLeaves.Rows)
    //            {
    //                LeavesCount objLeavesCount = new LeavesCount();
    //                objLeavesCount.LeaveId = row[0] == DBNull.Value ? 0 : Int32.Parse(row[0].ToString());
    //                objLeavesCount.LeaveName = row[1] == DBNull.Value ? "" : row[1].ToString();
    //                objLeavesCount.LeaveCount = row[2] == DBNull.Value ? 0 : Int32.Parse(row[2].ToString());
    //                lstLeavesAssigned.Add(objLeavesCount);
    //            }
    //        }

    //        return lstLeavesAssigned;
    //    }
}