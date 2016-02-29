USE [BiometricAttendanceManagementSystem]
GO

/****** Object:  StoredProcedure [dbo].[spGetLeavesAssignedToEmployeeSessionWise]    Script Date: 29-Feb-16 10:34:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		Software Incubator
-- Create date: 11th November 2015
-- Description:	Get All  Leaves  Assigned to Employees in  running Session
-- =============================================
CREATE PROCEDURE [dbo].[spGetLeavesAssignedToEmployeeSessionWise] 
	-- Add the parameters for the stored procedure here
	@employeeId bigint,
	@sessionStartDate datetime,
	@sessionEndDate datetime
AS
BEGIN
SELECT tblTypeOfLeave.Id,tblTypeOfLeave.Name , COUNT(LeavetypeId)  AS count
From tblLeaveAssignedPerSession RIGHT OUTER JOIN  tblTypeOfLeave  
ON tblLeaveAssignedPerSession.LeaveTypeId = tblTypeOfLeave.Id
AND EmployeeId = @employeeId
AND @sessionStartDate >= CAST(SessionStartDate AS DATE)
AND @sessionEndDate <= CAST(SessionStartDate AS DATE)
Group BY LeavetypeId,tblTypeOfLeave.Id,tblTypeOfLeave.Name
END





GO


