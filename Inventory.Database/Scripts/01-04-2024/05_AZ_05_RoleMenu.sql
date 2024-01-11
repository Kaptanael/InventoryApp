USE [InventoryDB]
GO

/****** Object:  Table [dbo].[RoleMenu]    Script Date: 1/11/2024 12:57:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RoleMenu](
	[RoleId] [uniqueidentifier] NOT NULL,
	[MenuId] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[RoleMenu]  WITH CHECK ADD  CONSTRAINT [FK_RoleMenu_Menu] FOREIGN KEY([MenuId])
REFERENCES [dbo].[Menu] ([Id])
GO

ALTER TABLE [dbo].[RoleMenu] CHECK CONSTRAINT [FK_RoleMenu_Menu]
GO

ALTER TABLE [dbo].[RoleMenu]  WITH CHECK ADD  CONSTRAINT [FK_RoleMenu_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO

ALTER TABLE [dbo].[RoleMenu] CHECK CONSTRAINT [FK_RoleMenu_Role]
GO


