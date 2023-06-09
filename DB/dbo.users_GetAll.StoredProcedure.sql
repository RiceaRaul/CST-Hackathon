USE [cst]
GO
/****** Object:  StoredProcedure [dbo].[users_GetAll]    Script Date: 4/2/2023 2:29:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[users_GetAll]
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
  FROM [cst].[dbo].[users]
END
GO
