USE [cst]
GO
/****** Object:  StoredProcedure [dbo].[rooms_generateRoom]    Script Date: 4/2/2023 2:29:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[rooms_generateRoom]
AS
BEGIN
   DECLARE @max_attempts INT = 100;
    DECLARE @temp_code VARCHAR(255);
    DECLARE @id INT;
    DECLARE @status INT = 0; -- Set default status to 0
    
    SELECT @id = IDENT_CURRENT('rooms') + 1;
    
    -- Generate a unique room code up to 10 times
    DECLARE @attempts INT = 0;
    WHILE @attempts < 10
    BEGIN
        SET @temp_code = CONCAT('ROOM-', RIGHT('00000' + CAST(@id AS VARCHAR(5)), 5), '-', RIGHT('00000' + CAST(FLOOR(RAND() * 100000) AS VARCHAR(5)), 5));
        
        -- Check if the room code already exists in the table
        IF NOT EXISTS (SELECT 1 FROM rooms WHERE roomcode = @temp_code)
        BEGIN
            -- Insert the unique room code into the table
            INSERT INTO rooms (roomcode) VALUES (@temp_code);
			SELECT [id]
				  ,[roomcode]
				  ,[status]
			  FROM [cst].[dbo].[rooms] WHERE id = SCOPE_IDENTITY()
            RETURN;
        END;
        
        SET @attempts = @attempts + 1;
    END;
    
    -- If we've attempted to generate a unique room code 10 times and failed, raise an error
    RAISERROR('Failed to generate a unique room code after 10 attempts.', 16, 1);
END;
GO
