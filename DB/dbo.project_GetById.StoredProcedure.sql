USE [cst]
GO
/****** Object:  StoredProcedure [dbo].[project_GetById]    Script Date: 4/2/2023 2:29:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[project_GetById]
	@id int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
		[id]
      ,[name]
      ,[description]
	  ,[author]
  FROM [cst].[dbo].[projects] where id = @id
END
GO
