IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'sp_set_booking_master'
)
DROP PROCEDURE dbo.sp_set_booking_master
GO
-- EXECUTE dbo.sp_bookslot 1,'M',getdate(),getdate(),0,1
CREATE PROCEDURE dbo.sp_set_booking_master
   @pd_id NUMERIC(6,0),
   @booking_type char(1), -- M,T,D 
   @bookingDate varchar(30),
   @slot_mapper varchar(max),
   @bookedFor NUMERIC(6,0) ,-- 0 for self non 0 id's for group id
   @bookedBy NUMERIC(6,0) --0 for admin non 0 id's for self
AS
   insert into booking_master(
                bm_pd_id,
                bm_booking_type,
                bm_booking_date,
                bm_booked_for,
                bm_booked_by,
                bm_slot_mapper
            )
            values(
                @pd_id,
                @booking_type,
                Convert(date,@bookingDate,103),
                @bookedFor,
                @bookedBy,
                @slot_mapper
            )
GO