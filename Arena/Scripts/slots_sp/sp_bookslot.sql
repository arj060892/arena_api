IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'sp_bookslot'
)
DROP PROCEDURE dbo.sp_bookslot
GO
-- EXECUTE dbo.sp_bookslot 1,'M',getdate(),getdate(),0,1
CREATE PROCEDURE dbo.sp_bookslot
   @pd_id NUMERIC(6,0),
   @bookingType VARCHAR(1), -- M,T,D
   @bookingDates NVARCHAR(max) , -- will contain dates in comma seperated format
   @bookedFor NUMERIC(6,0) ,-- 0 for self non 0 id's for group id
   @bookedBy NUMERIC(6,0), --0 for admin non 0 id's for self
   @slotId int
AS
    BEGIN TRANSACTION;
        BEGIN TRY
            IF @booking_type ='M'
            BEGIN
                DECLARE booking_cursor CURSOR FOR  
                SELECT  convert(varchar,sm_date,103) as Slot_Date 
                from slot_master(NOLOCK) where sm_date
                between DATEADD(month, datediff(month, 0, getdate()), 0) and 
                DATEADD(d, -1, DATEADD(m, DATEDIFF(m, 0, getdate()) + 1, 0))
                OPEN booking_cursor
                FETCH NEXT FROM booking_cursor     
                INTO @bookingDate
                WHILE @@FETCH_STATUS = 0    
                    BEGIN  
                        exec sp_update_slots @pd_id,@bookingType,@bookingDate,@slotId,@bookedFor,@bookedBy
                        FETCH NEXT FROM booking_cursor     
                        INTO @bookingDate
                    end
                CLOSE booking_cursor;    
                DEALLOCATE booking_cursor;
            END
            ELSE IF @booking_type = 'D'
            BEGIN   
                DECLARE booking_cursor CURSOR FOR  
                select Item from dbo.Split(@bookingDates,',')
                OPEN booking_cursor
                FETCH NEXT FROM booking_cursor     
                INTO @bookingDate
                WHILE @@FETCH_STATUS = 0    
                    BEGIN  
                        exec sp_update_slots @pd_id,@bookingType,@bookingDate,@slotId,@bookedFor,@bookedBy
                        FETCH NEXT FROM booking_cursor     
                        INTO @bookingDate
                    end
                CLOSE booking_cursor;    
                DEALLOCATE booking_cursor;
            END
        END TRY
        BEGIN CATCH 
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
GO

