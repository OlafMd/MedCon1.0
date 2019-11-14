INSERT INTO 
	cmn_str_sce_capacityrestriction_types
	(
		CMN_STR_SCE_CapacityRestriction_TypeID,
		CapacityRestrictionType_Name_DictID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_STR_SCE_CapacityRestriction_TypeID,
		@CapacityRestrictionType_Name,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)