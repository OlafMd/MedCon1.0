UPDATE 
	acc_bnk_bankaccount_types
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	BankAccountType_Name_DictID=@BankAccountType_Name,
	BankAccountType_Description_DictID=@BankAccountType_Description,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ACC_BNK_BankAccount_TypeID = @ACC_BNK_BankAccount_TypeID