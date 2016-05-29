USE [1gb_Gosreestr]
GO
/****** Object:  StoredProcedure [dbo].[spGetCategParentName]    Script Date: 29-май-16 17:33:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




create PROCEDURE [dbo].[spGetCategParentName]
	@id	 int = null
 AS

select name from categ where id =
(select parent from categ where id = @id)

GO
