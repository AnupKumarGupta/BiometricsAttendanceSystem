USE [BiometricAttendanceManagementSystem]
GO

/****** Object:  StoredProcedure [dbo].[spUpdateLeavesAssignedPerSession]    Script Date: 29-Feb-16 10:35:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		Software Incubator
-- Create date: 11th November 2015
-- Description:	Updates  Leaves  Assigned to Employees in  running Session
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateLeavesAssignedPerSession] 
	-- Add the parameters for the stored procedure here
	@employeeId bigint,
	@leaveTypeId int,
	@noOfLeaves int,
	@sessionStartDate datetime,
	@sessionEndDate datetime
AS
BEGIN
UPDATE [dbo].[tblLeaveAssignedPerSession]
   SET 
        [NoOfLeaves] = @noOfLeaves
   WHERE 
        EmployeeId = @employeeId AND
		LeaveTypeId = @leaveTypeId AND
		CAST(SessionStartDate AS DATE) = @sessionStartDate AND
		CAST(SessionEndDate AS DATE) = @sessionEndDate

END

GO


