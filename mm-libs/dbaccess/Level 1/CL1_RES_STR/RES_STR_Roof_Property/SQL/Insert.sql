INSERT INTO 
	res_str_roof_properties
	(
		RES_STR_Roof_PropertyID,
		GlobalPropertyMatchingID,
		RoofProperty_Name_DictID,
		RoofProperty_Description_DictID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@RES_STR_Roof_PropertyID,
		@GlobalPropertyMatchingID,
		@RoofProperty_Name,
		@RoofProperty_Description,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)