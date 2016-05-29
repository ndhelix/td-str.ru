USE [1gb_Gosreestr]
GO
/****** Object:  StoredProcedure [dbo].[spPageExist]    Script Date: 29-май-16 17:33:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




create PROCEDURE [dbo].[spPageExist]
	@categ	 int
,	@pagenum int 
,	@pagesize int = 50
 AS

if exists(
	select 1 from files
	where categ = @categ
	and numincateg > (@pagenum-1) * @pagesize
)
	select 1
else
	select 0


GO
