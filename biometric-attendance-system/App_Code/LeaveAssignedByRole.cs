using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LeaveAssignedByRole
/// </summary>
public class LeaveAssignedByRole
{
    public int Id { get; set; }
    public int RoleId { get; set; }
    public string RoleName { get; set; }
    public int LeaveTypeId { get; set; }
    public string LeaveName { get; set; }
    public int NoOfLeaves { get; set; }
    public bool IsPromoted { get; set; }
}