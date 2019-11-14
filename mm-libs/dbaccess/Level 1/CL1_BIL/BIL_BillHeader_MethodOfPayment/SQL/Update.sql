UPDATE 
	bil_billheader_methodofpayments
SET 
	BIL_BillHeader_RefID=@BIL_BillHeader_RefID,
	ACC_PAY_Type_RefID=@ACC_PAY_Type_RefID,
	IsPreferredMethodOfPayment=@IsPreferredMethodOfPayment,
	SequenceNumber=@SequenceNumber,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	BIL_BillHeader_MethodOfPaymentID = @BIL_BillHeader_MethodOfPaymentID