using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MonthlyReportOfEachEmployee
/// </summary>
public class MonthlyReportOfEmployee
{
    public MonthlyReportOfEmployee()
    {
        TotalDuration = new TimeSpan(0, 0, 0);
        PresentDays = 0;
        Leaves = 0;
        Holidays = 0;
        AbsentDays = 0;
        WeeklyOff = 0;
    }
    public TimeSpan TotalDuration { get; set; }
    public int PresentDays { get; set; }
    public int Leaves { get; set; }
    public int Holidays { get; set; }
    public int AbsentDays { get; set; }
    public int WeeklyOff { get; set; }

}