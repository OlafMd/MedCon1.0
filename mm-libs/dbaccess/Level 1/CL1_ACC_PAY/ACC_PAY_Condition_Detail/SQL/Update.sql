UPDATE 
	acc_pay_condition_details
SET 
	Conditions_RefID=@Conditions_RefID,
	DateInterval_From=@DateInterval_From,
	DateInterval_To=@DateInterval_To,
	DiscountPercentage=@DiscountPercentage,
	SequenceNumber=@SequenceNumber,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	ACC_PAY_Condition_DetailID = @ACC_PAY_Condition_DetailID