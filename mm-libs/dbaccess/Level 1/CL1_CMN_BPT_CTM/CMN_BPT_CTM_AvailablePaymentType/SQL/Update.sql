UPDATE 
	cmn_bpt_ctm_availablepaymenttypes
SET 
	ACC_PAY_Type_RefID=@ACC_PAY_Type_RefID,
	Customer_RefID=@Customer_RefID,
	IsDefaultPaymentType=@IsDefaultPaymentType,
	SequenceNumber=@SequenceNumber,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_BPT_CTM_AvailablePaymentTypeID = @CMN_BPT_CTM_AvailablePaymentTypeID