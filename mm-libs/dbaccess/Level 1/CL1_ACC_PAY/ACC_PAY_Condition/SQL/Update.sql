UPDATE 
	acc_pay_conditions
SET 
	PaymentCondition_Name_DictID=@PaymentCondition_Name,
	MaximumPaymentTreshold_InDays=@MaximumPaymentTreshold_InDays,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	ACC_PAY_ConditionID = @ACC_PAY_ConditionID