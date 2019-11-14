UPDATE 
	acc_cbx_cashboxes
SET 
	CashBoxName=@CashBoxName,
	CashBoxNumber=@CashBoxNumber,
	Currency_RefID=@Currency_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ACC_CBX_CashBoxID = @ACC_CBX_CashBoxID