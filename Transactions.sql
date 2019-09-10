USE [master]
GO

/****** Object:  Database [Banking]    Script Date: 9/10/2019 12:46:39 PM ******/
CREATE DATABASE [Banking]
go
use [Banking]
go
CREATE TABLE [dbo].[Transactions](
	[CustomerId_Sender] [int] NOT NULL,
	[CustomerId_Recipient] [int] NOT NULL,
	[AccountNo_Sender] [numeric](18, 0) NOT NULL,
	[AccountNo_Recipient] [numeric](18, 0) NOT NULL,
	[RecipientName] [nvarchar](50) NOT NULL,
	[Amount] [numeric](18, 2) NOT NULL,
	[TransactionType] [nvarchar](20) NOT NULL,
	[IFSC_Code] [nvarchar](50) NULL,
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