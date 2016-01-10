using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Shifts
{
    public int Id { get; set; }
    public TimeSpan FirstHalfStart { get; set; }
    public TimeSpan FirstHalfEnd { get; set; }
    public TimeSpan SecondHalfStart { get; set; }
    public TimeSpan SecondHalfEnd { get; set; }
    public bool IsActive { get; set; }
}