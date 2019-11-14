UPDATE 
	acc_pay_types
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	PaymentType_Name_DictID=@PaymentType_Name,
	IsCashPaymentType=@IsCashPaymentType,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ACC_PAY_TypeID = @ACC_PAY_TypeID