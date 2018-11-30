IF OBJECT_ID('[dbo].[group_dtls]', 'U') IS NOT NULL
DROP TABLE [dbo].[group_dtls]
GO
CREATE TABLE [dbo].[group_dtls]
(
    [gd_id] NUMERIC(6,0) IDENTITY(1,1) NOT NULL PRIMARY KEY, -- Primary Key column
    [gd_gm_id] NUMERIC(6,0) NOT NULL FOREIGN Key REFERENCES group_master(gm_id),
    [gd_member_name] VARCHAR(50) NOT NULL,
    [gd_created_by] DATETIME DEFAULT getdate() NOT NULL
);
GO