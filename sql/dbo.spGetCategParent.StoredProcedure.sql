USE [1gb_Gosreestr]
GO
/****** Object:  StoredProcedure [dbo].[spGetCategParent]    Script Date: 29-май-16 17:33:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




create PROCEDURE [dbo].[spGetCategParent]
	@id	 int = null
 AS

select parent from categ where id = @id

GO
