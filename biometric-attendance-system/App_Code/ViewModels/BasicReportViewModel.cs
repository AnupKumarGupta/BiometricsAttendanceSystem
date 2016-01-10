using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// ViewModel for Basic Reports
/// </summary>
public class BasicReportViewModel
{
    public BasicReportViewModel()
    {
    }
    public int EmployeeCode { get; set; }
    public string Name { get; set; }
    protected DateTime _secondHalfStartTime;
    public string SecondHalfStartTime
    {
        get { return _secondHalfStartTime.ToShortTimeString(); }
        set { _secondHalfStartTime = Convert.ToDateTime(value); }
    }

    protected DateTime _firstHalfStartTime;
    public string FirstHalfStartTime
    {
        get { return _firstHalfStartTime.ToShortTimeString(); }
        set { _firstHalfStartTime = Convert.ToDateTime(value); }
    }

    protected DateTime _inTime;
    public string InTime
    {
        get { return _inTime.ToShortTimeString(); }
        set { _inTime = Convert.ToDateTime(value); }
    }
    protected DateTime _outTime;
    public string OutTime
    {
        get { return _outTime.ToShortTimeString(); }
        set { _outTime = Convert.ToDateTime(value); }
    }
    public TimeSpan Duration { get { return (_outTime - _inTime); } }
    /// Logic for Shift Type based on _inTime/_outTime
    public BAS.Enums.Shift Shift
    {
        get
        {
            if (_inTime < _secondHalfStartTime)
                return BAS.Enums.Shift.GS;
            else
                return BAS.Enums.Shift.NS;
        }

        set
        {
            if (_inTime < _secondHalfStartTime)
                value = BAS.Enums.Shift.GS;
            else
                value = BAS.Enums.Shift.NS;
        }
    }
    ///All Logics Here for All STatus based on _inTime/_outTime
    public string Status
    {
        get;
        set;
    }
    public string Remarks { get; set; }
    public string TotalDuration { get { return this.Duration.ToString(); } set { value = this.Duration.ToString(); } }
}