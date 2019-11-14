UPDATE 
	bil_billheader_2_installmentplans
SET 
	BIL_BillHeader_RefID=@BIL_BillHeader_RefID,
	BIL_InstallmentPlan_RefID=@BIL_InstallmentPlan_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	BIL_BillHeader_2_InstallmentPlanID = @BIL_BillHeader_2_InstallmentPlanID