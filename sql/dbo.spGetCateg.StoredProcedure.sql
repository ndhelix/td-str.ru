USE [1gb_Gosreestr]
GO
/****** Object:  StoredProcedure [dbo].[spGetCateg]    Script Date: 29-май-16 17:33:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[spGetCateg]
	@parent	 int = null
 AS

if @parent = 0 set @parent = null
select * from categ
where parent = @parent or
( @parent is null and  parent is null)

--[spGetCateg] 1


GO
