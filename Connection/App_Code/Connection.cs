using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Connection
/// </summary>
public class Connection
{
    public zkemkeeper.CZKEMClass axCZKEM1 = new zkemkeeper.CZKEMClass();
    public string ConnectionString { get; set; }

    public Connection()
    {
        ConnectionString = ConfigurationManager.ConnectionStrings["Default"].ToString();
    }

    public void GetData(string ip = "192.168.0.192", int port = 4370)
    {
        var bIsConnected = axCZKEM1.Connect_Net(ip, port);
        axCZKEM1.EnableDevice(1, false);//disable the device
        string sdwEnrollNumber = "";
        int idwVerifyMode = 0;
        int idwInOutMode = 0;
        int idwYear = 0;
        int idwMonth = 0;
        int idwDay = 0;
        int idwHour = 0;
        int idwMinute = 0;
        int idwSecond = 0;
        int idwWorkcode = 0;
        int iMachineNumber = 1;
        // List<UserData> lstUserData = new List<UserData>();
        axCZKEM1.EnableDevice(iMachineNumber, false);//disable the device

        try
        {
            if (axCZKEM1.ReadGeneralLogData(iMachineNumber))//read all the attendance records to the memory
            {
                while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber, out idwVerifyMode,
                           out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkcode))//get records from the memory
                {
                    DateTime dateTime = Convert.ToDateTime(idwYear.ToString() + "-" + idwMonth.ToString() + "-" + idwDay.ToString() + " " + idwHour.ToString() + ":" + idwMinute.ToString() + ":" + idwSecond.ToString());

                    int id = CheckEntry(Int32.Parse(sdwEnrollNumber), DateTime.Parse(dateTime.ToShortDateString()));
                    if (id == 0)
                    {

                        InsertEntry(Int32.Parse(sdwEnrollNumber), dateTime);
                    }
                    else
                    {
                        UpdateEntry(id, dateTime);
                    }
                    InsertIntoTemp(Int32.Parse(sdwEnrollNumber), dateTime);
                }
            }

            // axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
        }

        catch (Exception ex)
        {
            return;
        }
    }
    public int CheckEntry(int empId, DateTime date)
    {
        SqlConnection con = new SqlConnection(this.ConnectionString);
        string q = "Select SNo from tblAttendance where EmployeeId = @empId and [Date] = CAST ( @date AS datetime ) and [ExitTime] IS null";
        SqlCommand cmd = new SqlCommand(q, con);
        cmd.Parameters.Add(new SqlParameter("@empId", empId));
        cmd.Parameters.Add(new SqlParameter("@date", date));
        SqlDataAdapter dap = new SqlDataAdapter(cmd);
        string a = cmd.CommandText;
        DataSet ds = new DataSet();
        dap.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        }
        else return 0;
    }

    public void InsertEntry(int empId, DateTime dateTime)
    {
        SqlConnection con = new SqlConnection(this.ConnectionString);
        string q = "Insert into tblAttendance(EmployeeId,[Date],[EntryTime]) values (@empId,CONVERT(datetime,@date,111),@time)";
        SqlCommand cmd = new SqlCommand(q, con);
        cmd.Parameters.Add(new SqlParameter("@empId", empId));
        cmd.Parameters.Add(new SqlParameter("@date", dateTime));
        cmd.Parameters.Add(new SqlParameter("@time", dateTime.ToShortTimeString()));
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }

    public void UpdateEntry(int rowId, DateTime dateTime)
    {
        SqlConnection con = new SqlConnection(this.ConnectionString);
        string q = "Update tblAttendance Set [ExitTime]=@time where SNo = @rowId";
        SqlCommand cmd = new SqlCommand(q, con);
        cmd.Parameters.Add(new SqlParameter("@rowId", rowId));
        cmd.Parameters.Add(new SqlParameter("@time", dateTime.ToShortTimeString()));
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }

    public void InsertIntoTemp(int empId, DateTime dateTime)
    {
        SqlConnection con = new SqlConnection(this.ConnectionString);
        string q = "Insert into tblAttendanceTemp(EmployeeId,[Date],[EntryTime]) values (@empId,CONVERT(datetime,@date,111),@time)";
        SqlCommand cmd = new SqlCommand(q, con);
        cmd.Parameters.Add(new SqlParameter("@empId", empId));
        cmd.Parameters.Add(new SqlParameter("@date", dateTime));
        cmd.Parameters.Add(new SqlParameter("@time", dateTime.ToShortTimeString()));
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
}
