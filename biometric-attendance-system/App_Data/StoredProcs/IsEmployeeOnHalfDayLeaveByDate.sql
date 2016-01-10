SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Software Incubator
-- Create date: 25th October 2015
-- Description:	Checks whether employee is on half day leave by Date
-- =============================================
CREATE PROCEDURE spIsEmployeeOnHalfDayLeaveByDate 
	-- Add the parameters for the stored procedure here
	@employeeId bigint, 
	@date datetime 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT COUNT( Distinct objtblHalfDayLeave.Id)
	FROM tblHalfDayLeave objtblHalfDayLeave , tblLeave objTblLeave
	WHERE
		 objTblLeave.Id = objtblHalfDayLeave.LeaveId AND
		 objTblLeave.EmployeeId = @employeeId AND
		 CAST(objtblHalfDayLeave.Date AS date) =  CAST(@date AS date)
END
GO
