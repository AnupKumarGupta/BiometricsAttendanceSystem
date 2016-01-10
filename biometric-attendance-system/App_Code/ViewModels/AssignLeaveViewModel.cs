using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AssignLeaveViewModel
/// </summary>
public class AssignLeaveViewModel : Leaves
{
    public AssignLeaveViewModel() { }
    public int leaveId { get; set; }
    public DateTime Date { get; set; }
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
}