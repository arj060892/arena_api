IF OBJECT_ID('[dbo].[slot_master]', 'U') IS NOT NULL
DROP TABLE [dbo].[slot_master]
GO
CREATE TABLE [dbo].[slot_master]
(
    [sm_id] INT NOT NULL PRIMARY KEY identity(1,1), -- Primary Key column
    [sm_date] datetime NOT NULL,
    [sm_slot_1] char(7) NOT NULL DEFAULT('3,0,0,3'), --6 to 7 , sequence M,T,D,C
    [sm_slot_2] char(7) NOT NULL DEFAULT('3,0,0,3'), --7 to 8
    [sm_slot_3] char(7) NOT NULL DEFAULT('3,0,0,3'), --8 to 9
    [sm_slot_4] char(7) NOT NULL DEFAULT('0,0,3,3'), --9 to 10
    [sm_slot_5] char(7) NOT NULL DEFAULT('0,0,3,3'), --10 to 11
    [sm_slot_6] char(7) NOT NULL DEFAULT('0,0,3,3'), --11 to 12
    [sm_slot_7] char(7) NOT NULL DEFAULT('0,0,3,3'), --12 to 13
    [sm_slot_8] char(7) NOT NULL DEFAULT('0,0,3,3'), --13 to 14
    [sm_slot_9] char(7) NOT NULL DEFAULT('0,0,3,3'), --14 to 15
    [sm_slot_10] char(7) NOT NULL DEFAULT('0,0,3,3'), --15 to 16
    [sm_slot_11] char(7) NOT NULL DEFAULT('0,0,3,3'), --16 to 17
    [sm_slot_12] char(7) NOT NULL DEFAULT('0,0,3,3'), --17 to 18
    [sm_slot_13] char(7) NOT NULL DEFAULT('3,0,0,3'), --18 to 19
    [sm_slot_14] char(7) NOT NULL DEFAULT('3,0,0,3'), --19 to 20
    [sm_slot_15] char(7) NOT NULL DEFAULT('3,0,0,3'), --20 to 21
    [sm_slot_16] char(7) NOT NULL DEFAULT('0,0,3,3'), --21 to 22
    [sm_slot_17] char(7) NOT NULL DEFAULT('0,0,3,3'), --22 to 23
);
GO