SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Software Incubator
-- Create date: 25th October 2015
-- Description:	Assign a Full day leave
-- =============================================
CREATE PROCEDURE spAssignFullDayLeave 
	-- Add the parameters for the stored procedure here
	@employeeId bigint = 0, 
	@date datetime = 0,
	@leaveTypeId int,
	@createdAt datetime,
	@updatedAt datetime
AS
BEGIN
	SET NOCOUNT ON;
    declare @leaveId int
	INSERT INTO tblLeave values(@employeeId,@leaveTypeId,@createdAt,@updatedAt,0);
	SET @leaveId = @@IDENTITY
	INSERT INTO tblFullDayLeave values(@leaveId,@date,@createdAt,@updatedAt);
END
GO
