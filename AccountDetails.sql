USE [master]
GO

/****** Object:  Database [Banking]    Script Date: 9/10/2019 12:42:18 PM ******/
CREATE DATABASE [Banking]
 go
 use [Banking]
 go
 CREATE TABLE [dbo].[AccountDetails](
	[CustomerID] [int] NOT NULL,
	[AccountNumber] [numeric](18, 0) NOT NULL,
	[BranchName] [nvarchar](50) NULL,
	[CurrentBalance] [numeric](18, 2) NULL,
	[Name] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[MobileNumber] [nvarchar](50) NULL,
	[Address] [nvarchar](100) NULL,
	[AccountStatus] [nvarchar](50) NOT NULL,
	[NetBankingPassword] [nvarchar](50) NOT NULL,
	[TransactionPassword] [nvarchar](50) NULL,
	[DOB] [date] NULL,
	[Gender] [nchar](10) NULL,
 CONSTRAINT [PK_AccountDetails] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[AccountDetails] ADD  CONSTRAINT [DF_AccountDetails_AccountStatus]  DEFAULT ((0)) FOR [AccountStatus]
GO

ALTER TABLE [dbo].[AccountDetails]  WITH CHECK ADD  CONSTRAINT [FK_AccountDetails_AccountDetails] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[AccountDetails] ([CustomerID])
GO

ALTER TABLE [dbo].[AccountDetails] CHECK CONSTRAINT [FK_AccountDetails_AccountDetails]
GO