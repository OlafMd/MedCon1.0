INSERT INTO 
	cmn_str_sce_capacityrestrictions
	(
		CMN_STR_SCE_CapacityRestrictionID,
		CapacityRestrictionType_RefID,
		IsValueCalculated_InPercentage,
		IsValueCalculated_InHeadCount,
		IsValueCalculated_InWorkingHours,
		ValueCalculated,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_STR_SCE_CapacityRestrictionID,
		@CapacityRestrictionType_RefID,
		@IsValueCalculated_InPercentage,
		@IsValueCalculated_InHeadCount,
		@IsValueCalculated_InWorkingHours,
		@ValueCalculated,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)