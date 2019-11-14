UPDATE 
	bil_billheader_assignedpayments
SET 
	AssignedBy_BusinessParticipant_RefID=@AssignedBy_BusinessParticipant_RefID,
	BIL_BillHeader_RefID=@BIL_BillHeader_RefID,
	ACC_BOK_AccountingTransaction_RefID=@ACC_BOK_AccountingTransaction_RefID,
	AssignedValue=@AssignedValue,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	BIL_BillHeader_AssignedPaymentID = @BIL_BillHeader_AssignedPaymentID