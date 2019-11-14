UPDATE 
	bil_billheader_2_accountingtransactions
SET 
	ACC_BOK_Accounting_Transaction_RefID=@ACC_BOK_Accounting_Transaction_RefID,
	BIL_BillHeader_RefID=@BIL_BillHeader_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID