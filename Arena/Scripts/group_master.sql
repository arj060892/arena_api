IF OBJECT_ID('[dbo].[group_master]', 'U') IS NOT NULL
DROP TABLE [dbo].[group_master]
GO
CREATE TABLE [dbo].[group_master]
(
    [gm_id] NUMERIC(6,0) IDENTITY(1,1) NOT NULL PRIMARY KEY, -- Primary Key column
    [gm_created_by] NUMERIC(6,0) NOT NULL FOREIGN Key REFERENCES players_dtls(pd_id),
    [gm_name] NVARCHAR(50) NOT NULL,
    [gm_count] INT CHECK([gm_count]<=6),
    [gm_created_on] DATETIME DEFAULT getdate()
);
GO