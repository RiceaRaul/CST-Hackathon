USE [cst]
GO
/****** Object:  StoredProcedure [dbo].[tasks_GetByProject]    Script Date: 4/2/2023 2:29:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tasks_GetByProject]
	@project int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [id]
      ,[name]
      ,[description]
      ,[type]
      ,[resultcode]
      ,[projectid]
      ,[userid]
  FROM [cst].[dbo].[tasks] where projectid = @project
END
GO
