USE [BiometricAttendanceManagementSystem]
GO

/****** Object:  StoredProcedure [dbo].[spGetAllEmployeesByRole]    Script Date: 01-Mar-16 10:38:17 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Software Incubator
-- Create date: 26th December 2015
-- Description:	Returns All Employees Of a Particular role
-- =============================================
CREATE PROCEDURE [dbo].[spGetAllEmployeesByRole] 
	@roleId int = 0
AS
BEGIN
     SET NOCOUNT ON;
	 SELECT objtblEmployeesMaster.Id AS EmployeeId,
			objtblEmployeesMaster.Name AS Name,
			objtblRole.Id AS RoleId,
			objtblRole.Name AS RoleName,
			objtblDepartment.Id AS DepartmentId,
			objtblDepartment.Name AS DepartmentName
	 FROM tblEmployeesMaster objtblEmployeesMaster, tblEmployees objtblEmployees,tblRole objtblRole,tblDepartment objtblDepartment
 	 WHERE objtblEmployeesMaster.Id = objtblEmployees.EmployeeId
	 AND  objtblEmployeesMaster.IsDeleted = 0  
	 AND  objtblEmployees.RoleId = objtblRole.Id
	 AND  objtblEmployees.RoleId = @roleId
	 AND objtblDepartment.Id = objtblEmployees.DepartmentId
END



GO


