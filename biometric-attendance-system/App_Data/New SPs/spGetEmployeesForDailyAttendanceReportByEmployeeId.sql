USE [BiometricAttendanceManagementSystem]
GO

/****** Object:  StoredProcedure [dbo].[spGetEmployeesForDailyAttendanceReportByEmployeeId]    Script Date: 18-Mar-16 3:23:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:  	Software Incubator
-- Create date: 19th December 2015
-- Description:	Get All Employees For Basic Report sorted by EmployeeId
-- =============================================
CREATE PROCEDURE [dbo].[spGetEmployeesForDailyAttendanceReportByEmployeeId]
-- Add the parameters for the stored procedure here
@date datetime,
@employeeId int
AS
BEGIN
   SELECT
  DISTINCT
    tblEmployeesMaster.Name AS Name,
    tblEmployeesMaster.Id,
    min(tblAttendance.EntryTime),
    max(tblAttendance.ExitTime)

  FROM tblEmployees,tblAttendance
  RIGHT OUTER JOIN tblEmployeesMaster
    ON tblAttendance.EmployeeId = tblEmployeesMaster.Id
    AND tblAttendance.Date = @date
  WHERE  tblEmployeesMaster.id =@employeeId
    GROUP BY
			  tblEmployeesMaster.Id,
		      tblEmployeesMaster.Name

END





GO


