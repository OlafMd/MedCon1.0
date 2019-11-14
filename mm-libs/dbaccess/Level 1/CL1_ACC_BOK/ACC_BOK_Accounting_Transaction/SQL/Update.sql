UPDATE 
	acc_bok_accounting_transactions
SET 
	Comment=@Comment,
	TransactionType_RefID=@TransactionType_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ACC_BOK_Accounting_TransactionID = @ACC_BOK_Accounting_TransactionID