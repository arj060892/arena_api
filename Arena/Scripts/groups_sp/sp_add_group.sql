IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'sp_add_group'
)
DROP PROCEDURE dbo.sp_add_group
GO
-- EXECUTE dbo.sp_add_group 1,'akhil','saa,as,sd,as'
CREATE PROCEDURE dbo.sp_add_group
    @created_by NUMERIC(6,0),
    @name NVARCHAR(50),
    @memberNames NVARCHAR(max) -- comma seperated names
AS
    declare @identity NUMERIC(6,0);
    declare @playerCount int;
    BEGIN TRANSACTION;
        BEGIN TRY
            select @playerCount = CHARINDEX(',',@memberNames);
            insert into group_master(
                gm_created_by,
                gm_name,
                gm_count
            )
            values(
                @created_by,
                @name,
                @playerCount
            )
            SELECT @identity = SCOPE_IDENTITY();

            insert into group_dtls(gd_gm_id,gd_member_name)
            select @identity,Item from dbo.Split(@memberNames,',')
        END TRY
        BEGIN CATCH 
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
GO