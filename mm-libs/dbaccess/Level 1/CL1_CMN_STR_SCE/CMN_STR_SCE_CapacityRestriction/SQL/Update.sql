UPDATE 
	cmn_str_sce_capacityrestrictions
SET 
	CapacityRestrictionType_RefID=@CapacityRestrictionType_RefID,
	IsValueCalculated_InPercentage=@IsValueCalculated_InPercentage,
	IsValueCalculated_InHeadCount=@IsValueCalculated_InHeadCount,
	IsValueCalculated_InWorkingHours=@IsValueCalculated_InWorkingHours,
	ValueCalculated=@ValueCalculated,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_STR_SCE_CapacityRestrictionID = @CMN_STR_SCE_CapacityRestrictionID