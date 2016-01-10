SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Software Incubator
-- Create date: 04th October 2015
-- Description:	Add an entry to Duration Table
-- =============================================
CREATE PROCEDURE spAddDuration 
	-- Add the parameters for the stored procedure here
	@duration time(7),
	@isActive bit,
	@createdOn datetime,
	@updatedOn datetime,
	@isDeleted bit
AS
BEGIN
	SET NOCOUNT ON;
    INSERT INTO 
     tblDuration 
	 VALUES(
			@duration,
			@isActive,
			@createdOn,
			@updatedOn,
			@isDeleted
		   )
END
GO
