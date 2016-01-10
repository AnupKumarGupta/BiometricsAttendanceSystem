using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Duration
/// </summary>
public class Duration
{
    public int Id { get; set; }
    public TimeSpan duration { get; set; }
    public bool IsActive { get; set; }
    public int leaveId { get; set; }
    public string leaveName { get; set; }
}