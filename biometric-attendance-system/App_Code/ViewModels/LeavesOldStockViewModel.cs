using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LeavesOldStockViewModel
/// </summary>
public class LeavesOldStockViewModel
{
    public LeavesOldStockViewModel() { }
    public int employeeId { get; set; }
    public string employeeName { get; set; }
    public int slCount { get; set; }
    public int elCount { get; set; }
    public DateTime sessionStartDate { get; set; }
    public DateTime sessionEndDate { get; set; }
}