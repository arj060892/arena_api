-- Create a new table called '[player_dtls]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[player_dtls]', 'U') IS NOT NULL
DROP TABLE [dbo].[player_dtls]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[player_dtls]
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