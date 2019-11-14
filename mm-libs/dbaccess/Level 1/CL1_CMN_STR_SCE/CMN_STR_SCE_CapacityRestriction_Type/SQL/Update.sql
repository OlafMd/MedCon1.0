UPDATE 
	cmn_str_sce_capacityrestriction_types
SET 
	CapacityRestrictionType_Name_DictID=@CapacityRestrictionType_Name,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_STR_SCE_CapacityRestriction_TypeID = @CMN_STR_SCE_CapacityRestriction_TypeID