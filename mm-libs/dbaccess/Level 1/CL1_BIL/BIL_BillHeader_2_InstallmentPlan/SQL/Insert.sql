INSERT INTO 
	bil_billheader_2_installmentplans
	(
		BIL_BillHeader_2_InstallmentPlanID,
		BIL_BillHeader_RefID,
		BIL_InstallmentPlan_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@BIL_BillHeader_2_InstallmentPlanID,
		@BIL_BillHeader_RefID,
		@BIL_InstallmentPlan_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)