using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Report4
/// </summary>
public class EmployeeMonthlyDetailedReportViewModel : EmployeeMonthlyBasicReportViewModel
{

    public EmployeeMonthlyDetailedReportViewModel()
    {
        _shiftInTime = DateTime.Parse("08:30");
        _shiftOutTime = DateTime.Parse("16:10");
    }
    private DateTime _shiftInTime;
    public string ShiftInTime
    {
        get { return _shiftInTime.ToShortTimeString(); }
        set { _shiftInTime = Convert.ToDateTime(value); }
    }

    private DateTime _shiftOutTime;
    public string ShiftOutTime
    {
        get { return _shiftOutTime.ToShortTimeString(); }
        set { _shiftOutTime = Convert.ToDateTime(value); }
    }

  
    public string LateBy
    {
        get { return (_inTime-_shiftInTime).ToString(); }
         
    }

public string EarlyGoingBy
    {
        get {
            var span = (_shiftOutTime - _outTime);
            return span.TotalHours < 0 ?  "00:00" : span.ToString();
        }
         
    }

private static string _temppunch;
public string PunchRecords
{
    get
    {
        _temppunch = this.InTime + ":: in  ---  " + this.OutTime + "::out";
        return _temppunch;
    }
}
}
