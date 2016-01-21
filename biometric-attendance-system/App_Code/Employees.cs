using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Employees
/// </summary>
public class Employees
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Name { get; set; }
    public int RoleId { get; set; }
    public string RoleName { get; set; }
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Password { get; set; }
    public long ContactNumber { get; set; }
    public string Gender { get; set; }
    public string ImagePath { get; set; }
    public DateTime JoiningDate { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
    public int WeeklyOffDay { get; set; }
}