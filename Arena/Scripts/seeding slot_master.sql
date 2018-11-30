IF OBJECT_ID('[dbo].[tempDate_Table]', 'U') IS NOT NULL
DROP TABLE [dbo].[tempDate_Table]
GO

DECLARE @MinDate DATE = '20180101',
        @MaxDate DATE = '20181231';

SELECT  TOP (DATEDIFF(DAY, @MinDate, @MaxDate) + 1)
        slot_date = DATEADD(DAY, ROW_NUMBER() OVER(ORDER BY a.object_id) - 1, @MinDate)
        into tempDate_Table
FROM    sys.all_objects a
        CROSS JOIN sys.all_objects b ;
go

INSERT into slot_master(sm_date)
select 
slot_date from tempDate_Table
go

drop table tempDate_Table
go

SELECT * from slot_master