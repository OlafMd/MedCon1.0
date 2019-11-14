UPDATE 
	cmn_bpt_ctm_availablepaymentconditions
SET 
	Customer_RefID=@Customer_RefID,
	ACC_PAY_Condition_RefID=@ACC_PAY_Condition_RefID,
	IsDefaultPaymentCondition=@IsDefaultPaymentCondition,
	SequenceNumber=@SequenceNumber,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_BPT_CTM_AvailablePaymentConditionID = @CMN_BPT_CTM_AvailablePaymentConditionID