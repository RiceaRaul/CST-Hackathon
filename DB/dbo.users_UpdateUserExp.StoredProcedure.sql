USE [cst]
GO
/****** Object:  StoredProcedure [dbo].[users_UpdateUserExp]    Script Date: 4/2/2023 2:29:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[users_UpdateUserExp]
    @user varchar(50),
    @exp_amount INT
AS
BEGIN
	DECLARE @userId int
	
	SELECT @userId = id FROM users WHERE username = @user
    UPDATE [users]
    SET exp = exp + @exp_amount
    WHERE id = @userId
END
GO
