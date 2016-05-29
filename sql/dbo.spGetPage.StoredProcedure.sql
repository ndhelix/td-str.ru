USE [1gb_Gosreestr]
GO
/****** Object:  StoredProcedure [dbo].[spGetPage]    Script Date: 29-май-16 17:33:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[spGetPage]
	@categ	 int
,	@pagenum int = 1
,	@pagesize int = 50
 AS


select id, name, mark,numincateg from files 
where categ = @categ
AND numincateg > (@pagenum-1) * @pagesize
and	  numincateg <=  (@pagenum) * @pagesize
and body is not null
--[spGetPage] 129
GO
