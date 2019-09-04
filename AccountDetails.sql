USE [master]
GO

/****** Object:  Database [Banking]    Script Date: 9/4/2019 12:28:56 PM ******/
CREATE DATABASE [Banking]
go
use [Banking]
CREATE TABLE [dbo].[AccountDetails](
	[CustomerID] [int] NOT NULL,
	[AccountNumber] [numeric](18, 0) NOT NULL,
	[BranchName] [nvarchar](50) NOT NULL,
	[CurrentBalance] [numeric](18, 2) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[MobileNumber] [bigint] NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[AccountStatus] [nvarchar](50) NOT NULL,
	[NetBankingPassword] [nvarchar](50) NOT NULL,
	[TransactionPassword] [nvarchar](50) NOT NULL,
	[IFSC_Code] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AccountDetails] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[AccountDetails]  WITH CHECK ADD  CONSTRAINT [FK_AccountDetails_AccountDetails] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[AccountDetails] ([CustomerID])
GO

ALTER TABLE [dbo].[AccountDetails] CHECK CONSTRAINT [FK_AccountDetails_AccountDetails]
GO


