USE [Banking]
GO

/****** Object:  StoredProcedure [dbo].[sp_RegisterDetails]    Script Date: 9/10/2019 12:48:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[sp_RegisterDetails]
@Name nvarchar(50),
@Email nvarchar(50),
@MobileNumber nvarchar(50),
@Address nvarchar(100),
@NetBankingPassword nvarchar(50),
@TransactionPassword nvarchar(50),
@DOB date, 
@Gender nchar(10), 
@CustomerID int

as
begin 
update AccountDetails set 
Name=@Name ,
Email=@Email,
MobileNumber=@MobileNumber,
Address=@Address,
NetBankingPassword=@NetBankingPassword,
TransactionPassword=@TransactionPassword,
DOB=@DOB,
Gender=@Gender
where CustomerID=@CustomerID
end


GO


