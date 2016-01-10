USE [BiometricsAttendanceSystem]
GO

/****** Object:  StoredProcedure [dbo].[spGetPunchRecordsOfEmployeeDateWise]    Script Date: 21-Dec-15 3:43:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Software Incubator
-- Create date: 21st December 2015
-- Description:	Get Punch Records Of Employee By Date
-- =============================================
CREATE PROCEDURE [dbo].[spGetPunchRecordsOfEmployeeDateWise] 
	-- Add the parameters for the stored procedure here
	@employeeId bigint,
	@date datetime
AS
BEGIN
	 SELECT        tblAttendance.EntryTime AS EntryTime, tblAttendance.ExitTime AS ExitTime
     FROM          tblAttendance 
	 WHERE         tblAttendance.[Date] = @date AND 
	               tblAttendance.EmployeeId = @employeeId
END



GO

