IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'sp_get_groups'
)
DROP PROCEDURE dbo.sp_get_groups
GO
-- EXECUTE dbo.sp_get_groups 1
CREATE PROCEDURE dbo.sp_get_groups
    @createdBy NUMERIC(6,0)
AS
    select gm_name as 'Group Name',gm_count as 'Count',gd_member_name as 'Members'
    from group_master inner join group_dtls on group_master.gm_id=group_dtls.gd_gm_id
    where gm_created_by = @createdBy
GO