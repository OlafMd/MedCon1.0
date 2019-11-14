UPDATE 
	acc_ipl_installments
SET 
	InstallmentPlan_RefID=@InstallmentPlan_RefID,
	Amount=@Amount,
	PaymentDeadline=@PaymentDeadline,
	PaymentDueDate=@PaymentDueDate,
	PayedOnDate=@PayedOnDate,
	IsFullyPaid=@IsFullyPaid,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ACC_IPL_InstallmentID = @ACC_IPL_InstallmentID