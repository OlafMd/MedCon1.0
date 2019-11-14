INSERT INTO 
	acc_cbx_cashboxes
	(
		ACC_CBX_CashBoxID,
		CashBoxName,
		CashBoxNumber,
		Currency_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@ACC_CBX_CashBoxID,
		@CashBoxName,
		@CashBoxNumber,
		@Currency_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)