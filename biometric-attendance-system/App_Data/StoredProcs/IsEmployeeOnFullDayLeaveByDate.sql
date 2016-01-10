SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Software Incubator
-- Create date: 25th October 2015
-- Description:	Checks whether employee is on full day leave by Date
-- =============================================
CREATE PROCEDURE spIsEmployeeOnFullDayLeaveByDate 
	-- Add the parameters for the stored procedure here
	@employeeId bigint, 
	@date datetime 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT COUNT( Distinct objtblFullDayLeave.Id)
	FROM tblFullDayLeave objtblFullDayLeave , tblLeave objTblLeave
	WHERE
		 objTblLeave.Id = objtblFullDayLeave.LeaveId AND
		 objTblLeave.EmployeeId = @employeeId AND
		 CAST(objtblFullDayLeave.Date AS date) =  CAST(@date AS date)
END
GO
