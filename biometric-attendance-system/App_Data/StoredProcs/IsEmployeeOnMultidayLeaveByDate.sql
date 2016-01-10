SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Software Incubator
-- Create date: 25th October 2015
-- Description:	Checks whether employee is on multiday leave by Date
-- =============================================
CREATE PROCEDURE IsEmployeeOnMultidayLeaveByDate 
	-- Add the parameters for the stored procedure here
	@employeeId bigint, 
	@date datetime 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT COUNT( Distinct objTblMultiDayLeave.Id)
	FROM tblMultiDayLeave objTblMultiDayLeave , tblLeave objTblLeave
	WHERE
		 objTblLeave.Id = objTblMultiDayLeave.LeaveId AND
		 objTblLeave.EmployeeId = @employeeId AND
		 CAST(objTblMultiDayLeave.StartDate AS date) <= DATEADD(DAY, (0), CAST(@date AS date)) AND
		 CAST(objTblMultiDayLeave.EndDate AS date) >= DATEADD(DAY, (0), CAST(@date AS date))
END
GO
