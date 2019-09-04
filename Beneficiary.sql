USE [master]
GO

/****** Object:  Database [Banking]    Script Date: 9/4/2019 12:34:00 PM ******/
CREATE DATABASE [Banking]
go
use [Banking]
CREATE TABLE [dbo].[Beneficiary](
	[BeneficiaryName] [nvarchar](50) NOT NULL,
	[BeneficiaryIFSC] [nvarchar](50) NOT NULL,
	[BeneficiaryAccountNo] [numeric](18, 0) NOT NULL,
	[Status] [nvarchar](20) NOT NULL
) ON [PRIMARY]

GO

