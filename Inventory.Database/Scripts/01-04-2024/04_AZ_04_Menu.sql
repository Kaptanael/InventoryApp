USE [InventoryDB]
GO

/****** Object:  Table [dbo].[Menu]    Script Date: 1/11/2024 12:57:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Menu](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ParentMenuId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Menu] ADD  CONSTRAINT [DF_Menu_Id]  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_Menu_ParentMenu] FOREIGN KEY([ParentMenuId])
REFERENCES [dbo].[Menu] ([Id])
GO

ALTER TABLE [dbo].[Menu] CHECK CONSTRAINT [FK_Menu_ParentMenu]
GO


