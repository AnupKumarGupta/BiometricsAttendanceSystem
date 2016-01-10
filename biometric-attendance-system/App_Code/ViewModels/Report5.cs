using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Report5
/// </summary>
public class DayWiseInOutDurationReportViewModel
{
    public int EmployeeCode { get; set; }


    public string Name { get; set; }

    public List<TimeTracker> Tracker { get; set; }

    public DayWiseInOutDurationReportViewModel()
    {
        Tracker = new List<TimeTracker>();
    }

    public string InDuration
    {
        get
        {
            return this.Tracker.Sum(i=>Convert.ToDecimal(i.Duration)).ToString();
        }
    }

    public string OutDuration { get; set; }

    private string _records;
    public string PunchRecords { get
        {
            foreach (var item in Tracker)
            {
                _records = _records + item.InTime + ":in:::" + item.OutTime + ":out:::";
               
            }
            return _records;
        }
 }

}



