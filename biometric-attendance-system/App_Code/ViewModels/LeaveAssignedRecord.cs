using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LeaveAssignedRecord
/// </summary>
public class LeaveAssignedRecord
{
	public LeaveAssignedRecord(){}
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public List<LeavesCount> lstAssignedRecord { get; set; }

}