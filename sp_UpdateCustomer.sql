USE [Banking]
GO

/****** Object:  StoredProcedure [dbo].[sp_UpdateCustomer]    Script Date: 9/10/2019 12:49:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[sp_UpdateCustomer]
@Name nvarchar(50),
@MobileNumber nvarchar(50),
@Address nvarchar(100),
@NetBankingPassword nvarchar(50),
@CustomerID int
as
begin
update AccountDetails set 
Name=@Name , MobileNumber=@MobileNumber,
Address=@Address,NetBankingPassword=@NetBankingPassword
where CustomerID=@CustomerID
end
GO


