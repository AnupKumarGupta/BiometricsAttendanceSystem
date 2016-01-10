using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BAS;
using DALHelper;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for Day
/// </summary>
public class Day
{
    public Day()
    {
        Status = BAS.Enums.DayStatus.Active;
    }

    public DateTime Date { get; set; }
    public BAS.Enums.DayStatus Status { get; set; }


    

    public void Add(Day day)
    {

        DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["CSBiometricAttendance"].ConnectionString;
        List<SqlParameter> list_params = new List<SqlParameter>() { new SqlParameter("@date", day.Date), new SqlParameter("@status", day.Status) };
        try
        {
            using (DBDataHelper helper = new DBDataHelper())
            {
                helper.ExecSQL("Insert into [tblSpecialDays] values (@date,@status)", SQLTextType.Query, list_params);

            }

        }
        catch (Exception ex)
        {

        }
    }
}

