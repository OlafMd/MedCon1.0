INSERT INTO 
	res_str_hvacr_properties
	(
		RES_STR_HVACR_PropertyID,
		GlobalPropertyMatchingID,
		HVACRProperty_Name_DictID,
		HVACRProperty_Description_DictID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@RES_STR_HVACR_PropertyID,
		@GlobalPropertyMatchingID,
		@HVACRProperty_Name,
		@HVACRProperty_Description,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)