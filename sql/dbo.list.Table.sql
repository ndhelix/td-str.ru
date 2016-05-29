USE [1gb_Gosreestr]
GO
/****** Object:  Table [dbo].[list]    Script Date: 29-май-16 17:33:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[list](
	[num] [int] NOT NULL,
	[name] [varchar](255) NULL,
	[mark] [varchar](255) NULL,
	[mfr] [varchar](255) NULL,
	[country] [varchar](25) NULL,
	[code] [char](8) NULL,
	[avail] [bit] NULL,
 CONSTRAINT [PK_list] PRIMARY KEY CLUSTERED 
(
	[num] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
