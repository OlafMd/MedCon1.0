UPDATE 
	acc_bnk_banks
SET 
	BankName=@BankName,
	Country_RefID=@Country_RefID,
	BankNumber=@BankNumber,
	BICCode=@BICCode,
	RoutingNumber=@RoutingNumber,
	BankLocationComment=@BankLocationComment,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ACC_BNK_BankID = @ACC_BNK_BankID