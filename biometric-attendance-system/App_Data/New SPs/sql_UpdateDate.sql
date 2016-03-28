USE [BiometricAttendanceManagementSystem]
GO

UPDATE [dbo].[tblLeave]
   SET 
       [Date] = DATEADD(month,1,[Date])
 WHERE Id > 0
GO 


