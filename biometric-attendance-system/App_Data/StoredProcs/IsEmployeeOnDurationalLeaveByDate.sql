SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Software Incubator
-- Create date: 25th October 2015
-- Description:	Checks whether employee is on durational leave by Date
-- =============================================
CREATE PROCEDURE spIsEmployeeOnDurationalLeaveByDate 
	-- Add the parameters for the stored procedure here
	@employeeId bigint, 
	@date datetime 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT COUNT( Distinct objtblDurationalLeave.Id)
	FROM tblDurationalLeave objtblDurationalLeave , tblLeave objTblLeave
	WHERE
		 objTblLeave.Id = objtblDurationalLeave.LeaveId AND
		 objTblLeave.EmployeeId = @employeeId AND
		 CAST(objtblDurationalLeave.Date AS date) =  CAST(@date AS date)
END
GO
