UPDATE 
	acc_bok_accounting_transactiontypes
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	TransactionTypeName_DictID=@TransactionTypeName,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ACC_BOK_Accounting_TransactionTypeID = @ACC_BOK_Accounting_TransactionTypeID