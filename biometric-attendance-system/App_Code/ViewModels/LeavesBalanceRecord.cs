using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LeaveBalanceRecord
/// </summary>
public class LeavesBalanceRecord
{
    public LeavesBalanceRecord() { }
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public List<LeavesCount> lstLeavesOldStack { get; set; }
    public List<LeavesCount> lstLeavesDue { get; set; }
    public List<LeavesCount> lstLeavesAvailed { get; set; }
    public List<LeavesCount> lstLeavesBalance { get; set; }
}