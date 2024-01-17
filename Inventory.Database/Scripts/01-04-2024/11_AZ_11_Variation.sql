USE [InventoryDB]
GO

/****** Object:  Table [dbo].[Variation]    Script Date: 1/17/2024 12:53:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Variation](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [uniqueidentifier] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Variation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Variation] ADD  CONSTRAINT [DF_Variation_Id]  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[Variation]  WITH CHECK ADD  CONSTRAINT [FK_Variation_User_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[Variation] CHECK CONSTRAINT [FK_Variation_User_CreatedBy]
GO

ALTER TABLE [dbo].[Variation]  WITH CHECK ADD  CONSTRAINT [FK_Variation_User_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[Variation] CHECK CONSTRAINT [FK_Variation_User_UpdatedBy]
GO


