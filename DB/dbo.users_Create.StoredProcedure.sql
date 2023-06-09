USE [cst]
GO
/****** Object:  StoredProcedure [dbo].[users_Create]    Script Date: 4/2/2023 2:29:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[users_Create]
	@username varchar(50),
	@password varchar(50),
	@email varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	
	IF EXISTS(SELECT username from users where username = @username OR email = @email)
		THROW 500001,'Email address or username already exists!' , 1
	else
		INSERT INTO users (username,[password],email) VALUES(@username,@password,@email);
		SELECT  
			[id]
		  ,[email]
		  ,[username]
		  ,[password]
		  ,[level]
		  ,[exp]
		  ,[needexp]
		  ,[profileimg]
	  FROM [cst].[dbo].[users] where id = SCOPE_IDENTITY();
END
GO
