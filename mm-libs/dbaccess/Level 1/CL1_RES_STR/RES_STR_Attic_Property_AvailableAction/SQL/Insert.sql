INSERT INTO 
	res_str_attic_property_availableactions
	(
		RES_STR_Attic_Property_AvailableActionID,
		RES_STR_Attic_Property_RefID,
		RES_ACT_Action_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@RES_STR_Attic_Property_AvailableActionID,
		@RES_STR_Attic_Property_RefID,
		@RES_ACT_Action_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)