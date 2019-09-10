USE [master]
GO

/****** Object:  Database [Banking]    Script Date: 9/10/2019 12:45:22 PM ******/
CREATE DATABASE [Banking]
 go
 use [Banking]
 go
 CREATE TABLE [dbo].[Beneficiary](
	[CustomerID] [int] NOT NULL,
	[BeneficiaryName] [nvarchar](50) NOT NULL,
	[BeneficiaryIFSC] [nvarchar](50) NOT NULL,
	[BeneficiaryAccountNo] [numeric](18, 0) NOT NULL,
	[Status] [int] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Beneficiary] ADD  CONSTRAINT [DF_Beneficiary_Status]  DEFAULT ((0)) FOR [Status]
GO

ALTER TABLE [dbo].[Beneficiary]  WITH CHECK ADD  CONSTRAINT [FK_Beneficiary_AccountDetails] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[AccountDetails] ([CustomerID])
GO

ALTER TABLE [dbo].[Beneficiary] CHECK CONSTRAINT [FK_Beneficiary_AccountDetails]
GO
