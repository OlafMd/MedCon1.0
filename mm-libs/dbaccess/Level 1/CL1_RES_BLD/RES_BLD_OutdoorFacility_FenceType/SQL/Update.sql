UPDATE 
	res_bld_outdoorfacility_fencetypes
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	FenceType_Name_DictID=@FenceType_Name,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_BLD_OutdoorFacility_FenceTypeID = @RES_BLD_OutdoorFacility_FenceTypeID