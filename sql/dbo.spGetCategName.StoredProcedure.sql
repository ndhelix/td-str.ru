USE [1gb_Gosreestr]
GO
/****** Object:  StoredProcedure [dbo].[spGetCategName]    Script Date: 29-���-16 17:33:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[spGetCategName]
	@id	 int = null
,	@fileid	 int = null
 AS

if @id is not null
select name from categ where id = @id

if @fileid is not null 
select name from categ where id = 
(select categ from files where id = @fileid)
GO
