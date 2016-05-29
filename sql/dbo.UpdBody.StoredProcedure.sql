USE [1gb_Gosreestr]
GO
/****** Object:  StoredProcedure [dbo].[UpdBody]    Script Date: 29-май-16 17:33:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[UpdBody]
	@filename varchar(20)
,	@year char(2)
,	@body varchar(max)
 AS

update files
set body = @body
where filename = @filename
--and [year] = @year
GO
