USE [1gb_Gosreestr]
GO
/****** Object:  StoredProcedure [dbo].[spGetFileTitle]    Script Date: 29-май-16 17:33:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[spGetFileTitle]
	@id	 int = null
 AS

if @id is null return


select isnull(name,'') + ' ' + isnull(mark, '') from files where id = @id
GO
