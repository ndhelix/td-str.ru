USE [1gb_Gosreestr]
GO
/****** Object:  StoredProcedure [dbo].[spSearch]    Script Date: 29-לאי-16 17:33:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[spSearch]
	@s varchar(255) = ''
 AS

if @s = '' return
set @s = rtrim((@s))
select top 100
id, name , mark from files 
where (name + ' ' + mark) like '%'+@s+'%'
and body is not null

-- spSearch 'םל  '
GO
