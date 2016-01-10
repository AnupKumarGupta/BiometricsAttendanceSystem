SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Software Incubator
-- Create date: 03rd October 2015
-- Description:	Add a new type of Leave
-- =============================================
CREATE PROCEDURE spCreateTypeOfLeave 
	-- Add the parameters for the stored procedure here
	@name nvarchar(MAX), 
	@masterLeaveType int,
	@createdOn datetime,
	@updatedOn datetime,
	@isDeleted bit
AS
BEGIN
	SET NOCOUNT ON;
			INSERT INTO 
			tblTypeOfLeave 
			VALUES (
			@name,
			@masterLeaveType,
			@createdOn,
			@updatedOn,
			@isDeleted)
    END
GO
