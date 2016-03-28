USE [BiometricAttendanceManagementSystem]
GO

/****** Object:  StoredProcedure [dbo].[spAssignLeave]    Script Date: 18-Mar-16 2:58:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Software Incubator
-- Create date: 25th October 2015
-- Description:	Assign a Full day leave
-- =============================================
CREATE PROCEDURE [dbo].[spAssignLeave] 
	-- Add the parameters for the stored procedure here
	@employeeId bigint = 0, 
	@date datetime = 0,
	@leaveTypeId int,
	@createdAt datetime
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO tblLeave values(@employeeId,@date,@leaveTypeId,@createdAt,NULL,0);
END


GO


