UPDATE 
	acc_ipl_installmentplans
SET 
	Currency_RefID=@Currency_RefID,
	NominalValue=@NominalValue,
	DepositAmount=@DepositAmount,
	InstallmentPeriodType=@InstallmentPeriodType,
	InstallmentStart=@InstallmentStart,
	Current_InstallmentPlanStatus_RefID=@Current_InstallmentPlanStatus_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ACC_IPL_InstallmentPlanID = @ACC_IPL_InstallmentPlanID