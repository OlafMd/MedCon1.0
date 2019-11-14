UPDATE 
	acc_cbx_cashboxbalancechange_2_accountingtransaction
SET 
	ACC_CBX_CashBox_BalanceChange_RefID=@ACC_CBX_CashBox_BalanceChange_RefID,
	ACC_BOK_Accounting_Transaction_RefID=@ACC_BOK_Accounting_Transaction_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID