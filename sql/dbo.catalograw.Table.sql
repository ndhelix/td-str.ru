USE [1gb_Gosreestr]
GO
/****** Object:  Table [dbo].[catalograw]    Script Date: 29-май-16 17:33:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[catalograw](
	[num] [int] NULL,
	[categid] [int] NULL,
	[parentcategid] [int] NULL,
	[categ1] [varchar](255) NULL,
	[categ2] [varchar](255) NULL,
	[numinternal] [int] NULL,
	[code] [varchar](25) NULL,
	[name] [varchar](255) NULL,
	[mark] [varchar](255) NULL,
	[mfr] [varchar](255) NULL,
	[comment] [varchar](255) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
