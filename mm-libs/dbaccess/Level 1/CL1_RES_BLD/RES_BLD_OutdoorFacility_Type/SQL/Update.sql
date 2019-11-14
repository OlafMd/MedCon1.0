UPDATE 
	res_bld_outdoorfacility_types
SET 
	OutdoorFacilityType_Name_DictID=@OutdoorFacilityType_Name,
	OutdoorFacilityType_Description_DictID=@OutdoorFacilityType_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_BLD_OutdoorFacility_TypeID = @RES_BLD_OutdoorFacility_TypeID