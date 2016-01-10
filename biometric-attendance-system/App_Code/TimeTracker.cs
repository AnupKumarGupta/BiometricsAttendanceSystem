using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TimeTracker
/// </summary>
public class TimeTracker
{
    public int EmployeeID { get; set; }

    private DateTime _inTime;
    public string InTime
    {
        get { return _inTime.ToShortTimeString(); }
        set { _inTime = Convert.ToDateTime(value); }
    }

    private DateTime _outTime;
    public string OutTime
    {
        get { return _outTime.ToShortTimeString(); }
        set { _outTime = Convert.ToDateTime(value); }
    }


    public string Duration { get { return (_outTime - _inTime).TotalMinutes.ToString(); } }


}