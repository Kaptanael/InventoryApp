USE [InventoryDB]
GO

/****** Object:  Table [dbo].[Unit]    Script Date: 1/17/2024 12:52:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Unit](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ShortName] [nvarchar](50) NOT NULL,
	[AllowDecimal] [bit] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [uniqueidentifier] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Unit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Unit] ADD  CONSTRAINT [DF_Unit_Id]  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[Unit] ADD  CONSTRAINT [DF_Unit_AllowDecimal]  DEFAULT ((0)) FOR [AllowDecimal]
GO

ALTER TABLE [dbo].[Unit]  WITH CHECK ADD  CONSTRAINT [FK_Unit_User_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[Unit] CHECK CONSTRAINT [FK_Unit_User_CreatedBy]
GO

ALTER TABLE [dbo].[Unit]  WITH CHECK ADD  CONSTRAINT [FK_Unit_User_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[Unit] CHECK CONSTRAINT [FK_Unit_User_UpdatedBy]
GO


