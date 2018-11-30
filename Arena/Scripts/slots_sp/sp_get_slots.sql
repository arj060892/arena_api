IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'sp_get_slots'
)
DROP PROCEDURE dbo.sp_get_slots 
GO
-- EXECUTE dbo.sp_get_slots
CREATE PROCEDURE dbo.sp_get_slots
AS
   declare @sql varchar(max);
declare @sql_select varchar(max);
declare @sql_from varchar(max);
declare @sql_where varchar(max);
declare @sql_loop varchar(max);
set @sql_select ='select convert(varchar,sm_date,103) as Slot_Date, ';
set @sql_from ='from slot_master(nolock)';
set @sql_loop='';
DECLARE @i int = 1
WHILE @i<=17
BEGIN
  set @sql_loop = @sql_loop+'case when CHARINDEX('','',sm_slot_'+CONVERT(varchar(10),@i)+')>0
        then SUBSTRING(sm_slot_'+CONVERT(varchar(10),@i)+',1,CHARINDEX('','',sm_slot_'+CONVERT(varchar(10),@i)+')-1)
        else sm_slot_'+CONVERT(varchar(10),@i)+' end '''+CONVERT(varchar(10),@i)+'_M'',
    case when CHARINDEX('','',sm_slot_'+CONVERT(varchar(10),@i)+')>0
        then SUBSTRING(sm_slot_'+CONVERT(varchar(10),@i)+',3,CHARINDEX('','',sm_slot_'+CONVERT(varchar(10),@i)+')-1)
        else sm_slot_'+CONVERT(varchar(10),@i)+' end '''+CONVERT(varchar(10),@i)+'_T'',
    case when CHARINDEX('','',sm_slot_'+CONVERT(varchar(10),@i)+')>0
        then SUBSTRING(sm_slot_'+CONVERT(varchar(10),@i)+',5,CHARINDEX('','',sm_slot_'+CONVERT(varchar(10),@i)+')-1)
        else sm_slot_'+CONVERT(varchar(10),@i)+' end '''+CONVERT(varchar(10),@i)+'_D'' ,'
    set @i=@i+1;
END

set @sql_where = ' where sm_date between DATEADD(month, datediff(month, 0, getdate()), 0) and 
                  DATEADD(d, -1, DATEADD(m, DATEDIFF(m, 0, getdate()) + 2, 0))'
select @sql_loop = LEFT(@sql_loop, LEN(@sql_loop) - 1) 

set @sql = @sql_select + @sql_loop + @sql_from + @sql_where

exec(@sql);
GO