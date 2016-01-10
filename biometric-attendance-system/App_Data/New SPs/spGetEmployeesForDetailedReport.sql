USE [BiometricsAttendanceSystem]
GO

/****** Object:  StoredProcedure [dbo].[spGetEmployeesForDetailedReport]    Script Date: 21-Dec-15 3:44:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Software Incubator
-- Create date: 20th December 2015
-- Description:	Get All Employees For Detailed Report 
-- =============================================
CREATE PROCEDURE [dbo].[spGetEmployeesForDetailedReport] 
	-- Add the parameters for the stored procedure here
	@date datetime
AS
BEGIN
	 SELECT        tblEmployeesMaster.FirstName + ' ' + tblEmployeesMaster.MiddleName + ' ' + tblEmployeesMaster.LastName AS Name,tblAttendance.EmployeeId AS EmployeeId, Min(tblAttendance.EntryTime) AS EntryTime, Max(tblAttendance.ExitTime) AS ExitTime
     FROM          tblAttendance INNER JOIN
                   tblEmployeesMaster ON tblAttendance.EmployeeId = tblEmployeesMaster.Id
	 WHERE         tblAttendance.Date = @date
     GROUP BY
				   tblAttendance.EmployeeId,
				   tblEmployeesMaster.FirstName,
				   tblEmployeesMaster.MiddleName,
			       tblEmployeesMaster.LastName
END



GO

