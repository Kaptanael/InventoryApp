USE [InventoryDB]
GO

/****** Object:  Table [dbo].[Warehouse ]    Script Date: 1/11/2024 12:58:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Warehouse ](
	[Id] [uniqueidentifier] NOT NULL,
	[BranchId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[StreetAddress] [nvarchar](200) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Province] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [uniqueidentifier] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Warehouse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Warehouse ] ADD  CONSTRAINT [DF_Warehouse_Id]  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[Warehouse ]  WITH CHECK ADD  CONSTRAINT [FK_Warehouse _Branch] FOREIGN KEY([BranchId])
REFERENCES [dbo].[Branch] ([Id])
GO

ALTER TABLE [dbo].[Warehouse ] CHECK CONSTRAINT [FK_Warehouse _Branch]
GO

ALTER TABLE [dbo].[Warehouse ]  WITH CHECK ADD  CONSTRAINT [FK_Warehouse_User_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[Warehouse ] CHECK CONSTRAINT [FK_Warehouse_User_CreatedBy]
GO

ALTER TABLE [dbo].[Warehouse ]  WITH CHECK ADD  CONSTRAINT [FK_Warehouse_User_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[Warehouse ] CHECK CONSTRAINT [FK_Warehouse_User_UpdatedBy]
GO


