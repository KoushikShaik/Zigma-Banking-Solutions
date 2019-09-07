USE [Banking]
GO

/****** Object:  Table [dbo].[Transactions]    Script Date: 9/7/2019 5:58:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Transactions](
	[CustomerId_Sender] [int] NOT NULL,
	[CustomerId_Recipient] [int] NOT NULL,
	[AccountNo_Sender] [numeric](18, 0) NOT NULL,
	[AccountNo_Recipient] [numeric](18, 0) NOT NULL,
	[RecipientName] [nvarchar](50) NOT NULL,
	[Amount] [numeric](18, 2) NOT NULL,
	[TransactionType] [nvarchar](20) NOT NULL,
	[IFSC_Code] [nvarchar](50) NOT NULL,
	[TransactionDate] [datetime] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_AccountDetails] FOREIGN KEY([CustomerId_Sender])
REFERENCES [dbo].[AccountDetails] ([CustomerID])
GO

ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_AccountDetails]
GO

ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_AccountDetails1] FOREIGN KEY([CustomerId_Recipient])
REFERENCES [dbo].[AccountDetails] ([CustomerID])
GO

ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_AccountDetails1]
GO


