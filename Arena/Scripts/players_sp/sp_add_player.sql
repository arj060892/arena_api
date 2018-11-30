IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'sp_add_player'
)
DROP PROCEDURE dbo.sp_add_player
GO
-- EXECUTE dbo.sp_add_player 'akhil','akhilrj@gmail.com','8983625366','strong@1'
CREATE PROCEDURE dbo.sp_add_player
    @name NVARCHAR(50),
    @email_id NVARCHAR(50),
    @mobile_no NVARCHAR(10),
    @password NVARCHAR(100)
AS
   INSERT INTO [dbo].[players_dtls]
   ( 
    [pd_name], [pd_email_id], [pd_mobile_no], [pd_user_name], [pd_password]
   )
   VALUES
   ( 
    @name, @email_id, @mobile_no,@email_id,@password
   )
   GO
GO