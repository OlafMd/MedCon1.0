INSERT INTO 
	acc_bok_accounting_transactiontypes
	(
		ACC_BOK_Accounting_TransactionTypeID,
		GlobalPropertyMatchingID,
		TransactionTypeName_DictID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@ACC_BOK_Accounting_TransactionTypeID,
		@GlobalPropertyMatchingID,
		@TransactionTypeName,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)