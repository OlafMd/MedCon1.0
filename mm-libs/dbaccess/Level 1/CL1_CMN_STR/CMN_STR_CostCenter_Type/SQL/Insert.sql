INSERT INTO 
	cmn_str_costcenter_types
	(
		CMN_STR_CostCenter_TypeID,
		CostCenterType_Name_DictID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_STR_CostCenter_TypeID,
		@CostCenterType_Name,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)