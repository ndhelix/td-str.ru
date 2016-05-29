USE [1gb_Gosreestr]
GO
/****** Object:  UserDefinedFunction [dbo].[GetName]    Script Date: 29-май-16 17:33:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetName] ( 	@body varchar(255))

RETURNS varchar(100)
as begin
declare @ret varchar(30)

set @body = replace(@body, 'назначение и область применения', '')
set @body = replace(@body, 'описание', '')
set @body = replace(@body, '<h2>', '')
set @body = replace(@body, '<h1>', '')
set @body = replace(@body, '</h2>', '')
set @body = replace(@body, '<h4>', '')
set @body = replace(@body, '</h4>', '')
set @body = replace(@body, '<h3>', '')
set @body = replace(@body, '</h3>', '')
set @body = replace(@body, '</h1>', '')
set @body = replace(@body, '<p>', '')
set @body = replace(@body, '</p>', '')
set @body = replace(@body, '<td>', '')
set @body = replace(@body, '</td>', '')
set @body = replace(@body, char(13), '')
set @body = replace(@body, char(10), '')

declare @p int
set @p = charindex('предназначен', @body)
if @p > 0
	set @body =	substring(@body,1,@p-1)
set @p = charindex('(', @body)
if @p > 0
	set @body =	substring(@body,1,@p-1)

set @body = ltrim(rtrim(@body))

return @body 
end
GO
