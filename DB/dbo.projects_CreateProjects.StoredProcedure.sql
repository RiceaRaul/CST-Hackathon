USE [cst]
GO
/****** Object:  StoredProcedure [dbo].[projects_CreateProjects]    Script Date: 4/2/2023 2:29:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[projects_CreateProjects]
	@title varchar(50),
	@description varchar(MAX),
	@author varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @userId int
	
	SELECT @userId = id FROM users WHERE username = @author
	IF @userId IS NULL 
		THROW 500001,'This user dosn`t exist!' , 1

	IF EXISTS(SELECT [name] from projects where [name] = @title AND author = @author)
		THROW 500001,'This project alredy exist!' , 1
	ELSE
		INSERT INTO projects ([name],[description],author) 	VALUES(@title,@description,@userId)
	SELECT  [id]
      ,[name]
      ,[description]
      ,[author]
  FROM [cst].[dbo].[projects] WHERE id = SCOPE_IDENTITY()
END
GO
