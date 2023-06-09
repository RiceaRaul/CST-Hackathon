USE [cst]
GO
/****** Object:  StoredProcedure [dbo].[projects_CreateTask]    Script Date: 4/2/2023 2:29:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[projects_CreateTask]
	@name varchar(50),
	@description varchar(MAX),
	@type int,
	@resultcode varchar(50),
	@projectid int,
	@author varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @userId int
	
	SELECT @userId = id FROM users WHERE username = @author

	IF NOT EXISTS(SELECT [id] from projects where id = @projectid)
		THROW 500001, 'Project dosn`t exist' , 1
	IF EXISTS(SELECT [name] from tasks where [name] = @name AND projectid = @projectid)
		THROW 500001,'This task alredy exist in this project!' , 1
	ELSE
		INSERT INTO tasks ([name],[description],[type],[resultcode],projectid,userid) VALUES(@name,@description,@type,@resultcode,@projectid,@userId)

	SELECT [id]
      ,[name]
      ,[description]
      ,[type]
      ,[resultcode]
      ,[projectid]
      ,[userid]
  FROM [cst].[dbo].[tasks] WHERE id = SCOPE_IDENTITY();
END
GO
