USE [BiometricsAttendanceSystem]
GO

/****** Object:  StoredProcedure [dbo].[spGetEmployeesForDetailedReport]    Script Date: 22-Dec-15 12:21:04 PM ******/
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
SELECT        tblEmployeesMaster.FirstName + ' ' + tblEmployeesMaster.MiddleName + ' ' + tblEmployeesMaster.LastName AS Name,tblEmployeesMaster.Id AS EmployeeId, Min(tblAttendance.EntryTime) AS EntryTime, Max(tblAttendance.ExitTime) AS ExitTime
FROM          tblAttendance RIGHT OUTER JOIN   
              tblEmployeesMaster ON tblAttendance.EmployeeId = tblEmployeesMaster.Id
AND           tblAttendance.Date = @date
GROUP BY
			  tblAttendance.EmployeeId,
			  tblEmployeesMaster.Id,
		      tblEmployeesMaster.FirstName,
	    	  tblEmployeesMaster.MiddleName,
			  tblEmployeesMaster.LastName
END



GO

