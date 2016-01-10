SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Software Incubator
-- Create date: 04th October 2015
-- Description:	Returns list of durations 
-- =============================================
CREATE PROCEDURE spGetAllDurations 
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
			Id,
			Duration
	FROM tblDuration
	WHERE
			IsDeleted = 0 
END
GO
