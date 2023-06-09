USE [cst]
GO
/****** Object:  StoredProcedure [dbo].[users_getByUsername]    Script Date: 4/2/2023 2:29:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[users_getByUsername]
	@username varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT  
		[id]
      ,[email]
      ,[username]
      ,[level]
      ,[exp]
      ,[needexp]
      ,[profileimg]
  FROM [cst].[dbo].[users] where username = @username
END
GO
