IF OBJECT_ID('[dbo].[booking_master]', 'U') IS NOT NULL
DROP TABLE [dbo].[booking_master]
GO
CREATE TABLE [dbo].[booking_master]
(
    [bm_id] NUMERIC(6,0) NOT NULL IDENTITY(1,1)  PRIMARY KEY, -- Primary Key column
    [bm_pd_id] NUMERIC(6,0) NOT NULL FOREIGN Key REFERENCES players_dtls(pd_id),
    [bm_booking_type] char(1) NOT NULL, --M,T,D ie Monthly , Training or Daily
    [bm_booking_date] datetime,
    [bm_slot_mapper] varchar(max),
    [bm_booked_for] NUMERIC(6,0), -- 0 for self non 0 id's for group id
    [bm_booked_by] NUMERIC(6,0), -- 0 for admin non 0 id's for self
    [bm_booked_on] datetime DEFAULT getdate()
);
GO