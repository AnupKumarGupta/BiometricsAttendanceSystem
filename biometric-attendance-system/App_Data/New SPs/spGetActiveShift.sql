USE [BiometricsAttendanceSystem]
GO

/****** Object:  StoredProcedure [dbo].[spGetActiveShift]    Script Date: 21-Dec-15 3:40:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Software Incubator
-- Create date: 04th October 2015
-- Description:	Get all Shifts
-- =============================================
CREATE PROCEDURE [dbo].[spGetActiveShift]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
		Id,
		FirstHalfStart,
		FirstHalfEnd,
		SecondHalfStart,
		SecondHalfEnd
	FROM 
		tblShifts
	WHERE 
		IsDeleted =0 AND
		isActive =1
END

GO

