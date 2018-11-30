IF EXISTS (
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'sp_update_slots'
)
DROP PROCEDURE dbo.sp_update_slots
GO
-- EXECUTE dbo.sp_update_slots 1,'M','17/11/2018','2',0,1
CREATE PROCEDURE dbo.sp_update_slots
    @pd_id NUMERIC(6,0),
    @bookingType VARCHAR(1),
    @bookingDate nvarchar(50),
    @slotId int,
    @bookedFor NUMERIC(6,0) ,-- 0 for self non 0 id's for group id
    @bookedBy NUMERIC(6,0)
--0 for admin non 0 id's for self
AS
DECLARE      @currentVal nchar(7);
DECLARE      @m int;
DECLARE      @t int;
DECLARE      @d int;
DECLARE      @c int;
DECLARE      @sqlGet nvarchar(max);
DECLARE      @sqlSet nvarchar(max);
DECLARE      @updatedVal NCHAR(7);
DECLARE      @slot_mapper varchar(max)

BEGIN TRANSACTION;
BEGIN TRY            
            set @sqlGet ='select  @currentVal = sm_slot_'+CONVERT(varchar(10),@slotId)+' from slot_master(NOLOCK)
                          where convert(varchar,sm_date,103)='''+@bookingDate+''''
            PRINT @sqlGet
            EXEC sp_executesql @sqlGet, N' @currentVal nchar(7) OUTPUT', @currentVal OUTPUT;

             
           Select @m = Substring(@currentVal, 1,Charindex(',', @currentVal)-1) ,
    @t = Substring(@currentVal, 3,Charindex(',', @currentVal)-1),
    @d = Substring(@currentVal, 5,Charindex(',', @currentVal)-1),
    @c = Substring(@currentVal, 7,Charindex(',', @currentVal)-1)
            --Date format : 17/11/2018
            select @slot_mapper = REPLACE(@bookingDate,'/','')
            print @slot_mapper
            print @currentVal
            set  @slot_mapper = @slot_mapper+@bookingType+CONVERT(varchar(3),@slotId)+'C'+CONVERT(varchar(3),@c)
            print @slot_mapper
            IF (@bookingType = 'M') SET @m = (@m-1)
            ELSE IF (@bookingType = 'T') SET @t = (@t-1)
            ELSE IF (@bookingType = 'D') SET @d = (@d-1)

            set @c =(@c-1)
PRINT @c
            set @updatedVal = CONVERT(char(1),@m)+','+CONVERT(char(1),@t)+','+CONVERT(char(1),@d)+','+CONVERT(char(1),@c)+',';
PRINT @updatedVal
            set @sqlSet = 'update slot_master
                           set sm_slot_'+CONVERT(varchar(10),@slotId)+' = '''+@updatedVal+''' 
                           where convert(varchar,sm_date,103)='''+@bookingDate+''''
                           PRINT @sqlSet
            EXEC(@sqlSet)

            EXEC sp_set_booking_master @pd_id,@bookingType,@bookingDate,@slot_mapper,@bookedFor,@bookedBy
        END TRY
        BEGIN CATCH 
        PRINT 'Error'
        DECLARE @err_msg AS NVARCHAR(MAX);

SET @err_msg = ERROR_MESSAGE();
print @err_msg
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
GO

select  sm_slot_2 from slot_master(NOLOCK)
                          where convert(varchar,sm_date,103)='17/11/2018'

select * from booking_master