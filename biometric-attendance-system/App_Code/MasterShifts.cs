using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MasterShifts
/// </summary>
public class MasterShifts
{
    public int Id { get; set; }
    public string Name { get; set; }
    public TimeSpan FirstHalfStart { get; set; }
    public TimeSpan FirstHalfEnd { get; set; }
    public TimeSpan SecondHalfStart { get; set; }
    public TimeSpan SecondHalfEnd { get; set; }
    public TimeSpan SHLDuration { get; set; }
    public bool IsActive { get; set; }
}