SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Software Incubator
-- Create date: 03rd October 2015
-- Description:	Gets All Types of Leave
-- =============================================
CREATE PROCEDURE spGetAllTypeOfLeaves 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
	      Id,
		  Name,
		  MasterLeaveType 
    FROM  tblTypeOfLeave
	WHERE IsDeleted = 0
END
GO
