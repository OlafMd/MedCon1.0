UPDATE 
	acc_ipl_installment_2_accounttransactionpairbatch
SET 
	ACC_IPL_Installment_RefID=@ACC_IPL_Installment_RefID,
	ACC_BOK_Accounting_Transaction_RefID=@ACC_BOK_Accounting_Transaction_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID