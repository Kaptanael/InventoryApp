﻿USE [InventoryDB]
GO

/****** Object:  Table [dbo].[ProductSubType]    Script Date: 1/17/2024 12:51:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProductSubType](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[ProductTypeId] [uniqueidentifier] NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [uniqueidentifier] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ProductSubType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ProductSubType] ADD  CONSTRAINT [DF_ProductSubType_Id]  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[ProductSubType]  WITH CHECK ADD  CONSTRAINT [FK_ProductSubType_ProductType] FOREIGN KEY([Id])
REFERENCES [dbo].[ProductType] ([Id])
GO

ALTER TABLE [dbo].[ProductSubType] CHECK CONSTRAINT [FK_ProductSubType_ProductType]
GO

ALTER TABLE [dbo].[ProductSubType]  WITH CHECK ADD  CONSTRAINT [FK_ProductSubType_User_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[ProductSubType] CHECK CONSTRAINT [FK_ProductSubType_User_CreatedBy]
GO

ALTER TABLE [dbo].[ProductSubType]  WITH CHECK ADD  CONSTRAINT [FK_ProductSubType_User_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[ProductSubType] CHECK CONSTRAINT [FK_ProductSubType_User_UpdatedBy]
GO


