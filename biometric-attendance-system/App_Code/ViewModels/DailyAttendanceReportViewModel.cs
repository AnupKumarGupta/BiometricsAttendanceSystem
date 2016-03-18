using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// For Report 1 (Daily Attendance Report(Basic Report)
/// </summary>
public class DailyAttendanceReportViewModel
{
    public DailyAttendanceReportViewModel() { }
    public int EmployeeId { get; set; }
    public string Name { get; set; }

    public DateTime _firstHalfStartTime;
    public string FirstHalfStartTime
    {
        get { return _firstHalfStartTime.ToShortTimeString(); }
        set { _firstHalfStartTime = DateTime.Parse(value); }
    }

    public DateTime _firstHalfEndTime;
    public string FirstHalfEndTime
    {
        get { return _firstHalfEndTime.ToShortTimeString(); }
        set { _firstHalfEndTime = DateTime.Parse(value); }
    }

    public DateTime _secondHalfStartTime;
    public string SecondHalfStartTime
    {
        get { return _secondHalfStartTime.ToShortTimeString(); }
        set { _secondHalfStartTime = DateTime.Parse(value); }
    }

    public DateTime _secondHalfEndTime;
    public string SecondHalfEndTime
    {
        get { return _secondHalfEndTime.ToShortTimeString(); }
        set { _secondHalfEndTime = DateTime.Parse(value); }
    }
    protected TimeSpan _relaxation { get; set; }
    public string Relaxation
    {
        get { return _relaxation.ToString(); }
        set { _relaxation = TimeSpan.Parse(value); }
    }
    public DateTime Date { get; set; }
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
    public TimeSpan Duration { get; set; }
    public BAS.Enums.Status Status { get; set; }
    public string PunchRecords { get; set; }
    public TimeSpan LateByDuration { get; set; }
    public TimeSpan EarlyGoingByDuration { get; set; }
    public string TotalDuration { get { return this.Duration.ToString(); } set { value = this.Duration.ToString(); } }
}