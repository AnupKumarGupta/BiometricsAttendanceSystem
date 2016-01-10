USE [BiometricsAttendanceSystem]
GO

/****** Object:  StoredProcedure [dbo].[spCreateEmployee]    Script Date: 08-Oct-15 6:30:47 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		SI
-- Create date: 29thSeptember2015
-- Description:	Creates a new Employee and returns Employee ID of created Employee 
-- =============================================
CREATE PROCEDURE [dbo].[spCreateEmployee]
	-- Add the parameters for the stored procedure here
	@facultyId nvarchar(MAX),
	@firstName nvarchar(MAX), 
	@middleName nvarchar(MAX),
	@lastName nvarchar(MAX),
	@gender nvarchar(MAX),
	@dateOfBirth datetime,
	@joiningDate datetime,
	@isDeleted bit,
	@createdAt datetime,
	@updatedAt datetime
AS
BEGIN

	SET NOCOUNT ON;

   INSERT INTO dbo.tblEmployeesMaster
          ( 
            FacultyId,
			FirstName,
			MiddleName,
			LastName,
			Gender,
			DateOfBirth,
			JoiningDate,
			CreatedAt,
			UpdatedAt,
			IsDeleted
          ) 
     VALUES 
          ( 
            @facultyId,
			@firstName, 
			@middleName,
			@lastName,
			@gender,
			@dateOfBirth,
			@joiningDate,
			@createdAt,
			@updatedAt,
			@isDeleted
          ) 
	SELECT @@IDENTITY
END
GO


