using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DetailedReportViewModel
/// </summary>
public class DetailedReportViewModel : BasicReportViewModel
{
    public DetailedReportViewModel()
    {
    }
    private DateTime _firstHalfEndTime;
    public string FirstHalfEndTime
    {
        get { return _firstHalfEndTime.ToShortTimeString(); }
        set { _firstHalfEndTime = Convert.ToDateTime(value); }
    }
    private DateTime _secondHalfEndTime;
    public string SecondHalfEndTime
    {
        get { return _secondHalfEndTime.ToShortTimeString(); }
        set { _secondHalfEndTime = Convert.ToDateTime(value); }
    }
    public string ShiftInTime
    {
        get { return _firstHalfStartTime.ToShortTimeString(); }
        set { _firstHalfStartTime = Convert.ToDateTime(value); }
    }
    public string ShiftOutTime
    {
        get { return _secondHalfEndTime.ToShortTimeString(); }
        set { _secondHalfEndTime = Convert.ToDateTime(value); }
    }
    public TimeSpan LateByDuration
    {
        get
        {
            return (_firstHalfStartTime < _inTime) ? (_inTime - _firstHalfStartTime).Duration() : TimeSpan.Parse("00:00:00");
        }
    }
    public TimeSpan EarlyGoingByDuration
    {
        get
        {
            return (_inTime.TimeOfDay > TimeSpan.Parse("00:00:00")) ? ((_secondHalfEndTime > _outTime) ? (_secondHalfEndTime - _outTime).Duration() : TimeSpan.Parse("00:00:00")) : TimeSpan.Parse("00:00:00");
        }
    }
    public string PunchRecords { get; set; }
    public DateTime Date { get; set; }
}