INSERT INTO 
	tms_pro_projects
	(
		TMS_PRO_ProjectID,
		ProjectCode,
		DefaultLanguage_RefID,
		DOC_Structure_Header_RefID,
		Name_DictID,
		Description_DictID,
		Status_RefID,
		IsArchived,
		CreatedByAccount_RefID,
		BillingCurrency_RefID,
		Default_CostCenter_RefID,
		Color,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@TMS_PRO_ProjectID,
		@ProjectCode,
		@DefaultLanguage_RefID,
		@DOC_Structure_Header_RefID,
		@Name,
		@Description,
		@Status_RefID,
		@IsArchived,
		@CreatedByAccount_RefID,
		@BillingCurrency_RefID,
		@Default_CostCenter_RefID,
		@Color,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)