USE [cst]
GO
/****** Object:  StoredProcedure [dbo].[users_LoginUser]    Script Date: 4/2/2023 2:29:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[users_LoginUser]
	@username varchar(50),
	@password varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	
	IF EXISTS(SELECT username from users where username = @username)
		IF EXISTS(SELECT username from users where username = @username AND [password] = @password)
			return 1;
		ELSE
			THROW 500002,'Wrong password!' , 1
	ELSE
		THROW 500001,'This user does`t exist!' , 1
	
END
GO
