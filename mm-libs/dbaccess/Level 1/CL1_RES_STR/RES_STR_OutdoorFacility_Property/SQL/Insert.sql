INSERT INTO 
	res_str_outdoorfacility_properties
	(
		RES_STR_OutdoorFacility_PropertyID,
		GlobalPropertyMatchingID,
		OutdoorFacilityProperty_Name_DictID,
		OutdoorFacilityProperty_Description_DictID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@RES_STR_OutdoorFacility_PropertyID,
		@GlobalPropertyMatchingID,
		@OutdoorFacilityProperty_Name,
		@OutdoorFacilityProperty_Description,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)