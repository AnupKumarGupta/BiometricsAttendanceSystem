using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LeaveAssignedPerSession
/// </summary>
public class LeaveAssignedPerSession
{
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public List<TypeOfLeave> lstLeaveType { get; set; }
    public int leaveType { get; set; }
    public int leaveCount { get; set; }
}