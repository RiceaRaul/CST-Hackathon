USE [cst]
GO
/****** Object:  StoredProcedure [dbo].[users_GetLeaderBord]    Script Date: 4/2/2023 2:29:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[users_GetLeaderBord]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT  
		[id]
      ,[email]
      ,[username]
      ,[password]
      ,[level]
      ,[exp]
      ,[needexp]
      ,[profileimg]
  FROM [cst].[dbo].[users] order by [exp] desc
END
GO
