USE [BiometricsAttendanceSystem]
GO

/****** Object:  StoredProcedure [dbo].[spGetEmployeesForBasicReport]    Script Date: 22-Dec-15 12:20:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Software Incubator
-- Create date: 19th December 2015
-- Description:	Get All Employees For Basic Report 
-- =============================================
CREATE PROCEDURE [dbo].[spGetEmployeesForBasicReport] 
	-- Add the parameters for the stored procedure here
	@date datetime
AS
BEGIN
	 SELECT        tblEmployeesMaster.FirstName + ' ' + tblEmployeesMaster.MiddleName + ' ' + tblEmployeesMaster.LastName AS Name, tblAttendance.EmployeeId, tblAttendance.EntryTime, tblAttendance.ExitTime, 
                   tblAttendance.Date
FROM          tblAttendance RIGHT OUTER JOIN   
              tblEmployeesMaster ON tblAttendance.EmployeeId = tblEmployeesMaster.Id
AND           tblAttendance.Date = @date

      
END



GO

