UPDATE 
	acc_bnk_bankaccountbalancechange_2_accountingtransaction
SET 
	ACC_BNK_BankAccount_BalanceChange_RefID=@ACC_BNK_BankAccount_BalanceChange_RefID,
	ACC_BOK_Accounting_Transaction_RefID=@ACC_BOK_Accounting_Transaction_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID