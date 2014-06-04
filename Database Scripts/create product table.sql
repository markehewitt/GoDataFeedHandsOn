USE [GoDataFeed]
GO

/****** Object:  Table [dbo].[product]    Script Date: 6/4/2014 10:20:28 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[product](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[retailerid] [bigint] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[sku] [nvarchar](20) NOT NULL,
	[price] [money] NOT NULL,
 CONSTRAINT [PK_product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[product] ADD  CONSTRAINT [DF_product_price]  DEFAULT ((0)) FOR [price]
GO

ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [FK_product_retailer] FOREIGN KEY([retailerid])
REFERENCES [dbo].[retailer] ([id])
GO

ALTER TABLE [dbo].[product] CHECK CONSTRAINT [FK_product_retailer]
GO

