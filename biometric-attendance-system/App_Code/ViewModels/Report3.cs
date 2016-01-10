using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Report3
/// </summary>
public class EmployeeMonthlyBasicReportViewModel 
{
    private DateTime _date;

    public string Date { get { return _date.ToShortDateString(); } set { _date = Convert.ToDateTime(value); } }

    public DateTime _inTime;
    public string InTime
    {
        get { return _inTime.ToShortTimeString(); }
        set { _inTime = Convert.ToDateTime(value); }
    }

    public DateTime _outTime;
    public string OutTime
    {
        get { return _outTime.ToShortTimeString(); }
        set { _outTime = Convert.ToDateTime(value); }
    }

    public TimeSpan Duration { get { return (_outTime - _inTime).Duration(); } }


    /// Logic for Shift Type based on _inTime/_outTime
    public BAS.Enums.Shift Shift
    {
        get
        {
            return BAS.Enums.Shift.GS;
        }

    }




    ///All Logics Here for All STatus based on _inTime/_outTime
    public BAS.Enums.Status Status
    { get; set; }

    public string Remarks { get; set; }


    public string TotalDuration
    {
        get { return Duration.ToString(); }

    }

    

    
}