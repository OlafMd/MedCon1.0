INSERT INTO 
	acc_bnk_bankaccountbalancechange_2_accountingtransaction
	(
		AssignmentID,
		ACC_BNK_BankAccount_BalanceChange_RefID,
		ACC_BOK_Accounting_Transaction_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@AssignmentID,
		@ACC_BNK_BankAccount_BalanceChange_RefID,
		@ACC_BOK_Accounting_Transaction_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)