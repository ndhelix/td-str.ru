USE [1gb_Gosreestr]
GO
/****** Object:  StoredProcedure [dbo].[spGetFile]    Script Date: 29-май-16 17:33:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[spGetFile]
	@id	 int = null
 AS

if @id is null return
declare @s varchar(255)
set @s = 'Изделие зарегистрировано в Госреестре под номером ' 
+ (select [filename] from files where id = @id)
set @s = '<p>'+@s+'</p>'

select @s+body from files where id = @id
GO
