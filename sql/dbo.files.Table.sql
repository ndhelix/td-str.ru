USE [1gb_Gosreestr]
GO
/****** Object:  Table [dbo].[files]    Script Date: 29-май-16 17:33:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[files](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[year] [char](2) NULL,
	[filename] [varchar](20) NULL,
	[code] [char](8) NULL,
	[body] [varchar](max) NULL,
	[name] [varchar](255) NULL,
	[mark] [varchar](255) NULL,
	[categ] [int] NULL,
	[numincateg] [int] NULL,
 CONSTRAINT [PK_files] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[files]  WITH CHECK ADD  CONSTRAINT [FK_files_categ] FOREIGN KEY([categ])
REFERENCES [dbo].[categ] ([id])
GO
ALTER TABLE [dbo].[files] CHECK CONSTRAINT [FK_files_categ]
GO
