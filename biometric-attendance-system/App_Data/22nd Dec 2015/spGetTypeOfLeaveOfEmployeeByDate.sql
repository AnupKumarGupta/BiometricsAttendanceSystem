USE [BiometricsAttendanceSystem]
GO

/****** Object:  StoredProcedure [dbo].[spGetTypeOfLeaveOfEmployeeByDate]    Script Date: 22-Dec-15 12:20:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Software Incubator
-- Create date: 21st December 2015
-- Description:	Get Type Of Leave Of Employee By Date
-- =============================================
CREATE PROCEDURE [dbo].[spGetTypeOfLeaveOfEmployeeByDate] 
	-- Add the parameters for the stored procedure here
	@employeeId bigint, 
	@date date
	

AS
BEGIN
    SELECT Name FROM  tblTypeOfLeave WHERE Id in(
	
	SELECT  Distinct objTblLeave.LeaveTypeId
	FROM tblMultiDayLeave objtblMultiDayLeave , tblLeave objTblLeave
	WHERE
		 objTblLeave.Id = objtblMultiDayLeave.LeaveId AND
		 objTblLeave.EmployeeId = @employeeId AND
		 CAST(objTblMultiDayLeave.StartDate AS date) <= DATEADD(DAY, (0), CAST(@date AS date)) AND
		 CAST(objTblMultiDayLeave.EndDate AS date) >= DATEADD(DAY, (0), CAST(@date AS date))
		
	UNION
		 
	SELECT Distinct objTblLeave.LeaveTypeId
	FROM tblFullDayLeave objtblFullDayLeave , tblLeave objTblLeave
	WHERE
		 objTblLeave.Id = objtblFullDayLeave.LeaveId AND
		 objTblLeave.EmployeeId = @employeeId AND
		 CAST(objtblFullDayLeave.Date AS date) =  CAST(@date AS date)	 

	UNion

	SELECT Distinct objTblLeave.LeaveTypeId
	FROM tblDurationalLeave objtblDurationalLeave , tblLeave objTblLeave
	WHERE
		 objTblLeave.Id = objtblDurationalLeave.LeaveId AND
		 objTblLeave.EmployeeId = @employeeId AND
		 CAST(objtblDurationalLeave.Date AS date) =  CAST(@date AS date)
		 
	Union

	SELECT Distinct objTblLeave.LeaveTypeId
	FROM tblHalfDayLeave objtblHalfDayLeave , tblLeave objTblLeave
	WHERE
		 objTblLeave.Id = objtblHalfDayLeave.LeaveId AND
		 objTblLeave.EmployeeId = @employeeId AND
		 CAST(objtblHalfDayLeave.Date AS date) =  CAST(@date AS date)	 
		 )

END

GO

