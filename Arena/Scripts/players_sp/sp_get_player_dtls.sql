-- Create a new stored procedure called 'sp_get_player_dtls' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'sp_get_player_dtls'
)
DROP PROCEDURE dbo.sp_get_player_dtls
GO
-- EXECUTE dbo.sp_get_player_dtls 1
CREATE PROCEDURE dbo.sp_get_player_dtls
   @playerId NUMERIC(6,0)
-- add more stored procedure parameters here
AS
    -- body of the stored procedure
    SELECT pd_name as 'name',pd_email_id as 'email',pd_mobile_no as 'mobile' from players_dtls(nolock) where pd_id=@playerId
GO