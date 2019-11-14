UPDATE 
	acc_ipl_installmentplan_status
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	InstallmentPlanStatus_Name_DictID=@InstallmentPlanStatus_Name,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ACC_IPL_InstallmentPlan_StatusID = @ACC_IPL_InstallmentPlan_StatusID