USE [InventoryDB]
GO

/****** Object:  Table [dbo].[Customer]    Script Date: 1/12/2024 3:21:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customer](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[BusinessSize] [nvarchar](50) NOT NULL,
	[StreetAddress] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[City] [nvarchar](50) NOT NULL,
	[Province] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_Id]  DEFAULT (newid()) FOR [Id]
GO


