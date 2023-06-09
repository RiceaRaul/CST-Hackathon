USE [cst]
GO
/****** Object:  StoredProcedure [dbo].[projects_GetByUser]    Script Date: 4/2/2023 2:29:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[projects_GetByUser]
	@user varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @userId int
	
	SELECT @userId = id FROM users WHERE username = @user
	SELECT [id]
      ,[name]
      ,[description]
	  ,[author]
  FROM [cst].[dbo].[projects] WHERE author = @userId;
END
GO
