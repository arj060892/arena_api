IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'sp_auth_player'
)
DROP PROCEDURE dbo.sp_auth_player
GO
-- EXECUTE dbo.sp_auth_player 'akhilrj@gmail.com','strong@j1'
CREATE PROCEDURE dbo.sp_auth_player
    @username NVARCHAR(50),
    @password NVARCHAR(100)
AS
    SELECT COUNT(pd_user_name) 'isUserValid' from players_dtls(nolock) 
    where pd_user_name = @username and pd_password = @password
GO