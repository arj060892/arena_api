IF OBJECT_ID('[dbo].[players_dtls]', 'U') IS NOT NULL
DROP TABLE [dbo].[players_dtls]
GO
CREATE TABLE [dbo].[players_dtls]
(
    [pd_id] NUMERIC(6,0) NOT NULL IDENTITY(1,1) PRIMARY KEY, -- Primary Key column
    [pd_name] NVARCHAR(50) NOT NULL,
    [pd_email_id] NVARCHAR(50) NOT NULL,
    [pd_mobile_no] NVARCHAR(10) NOT NULL,
    [pd_user_name] NVARCHAR(50) NOT NULL,
    [pd_password] NVARCHAR(100) NOT NULL,
    [pd_created_on] datetime DEFAULT getdate()
);
GO