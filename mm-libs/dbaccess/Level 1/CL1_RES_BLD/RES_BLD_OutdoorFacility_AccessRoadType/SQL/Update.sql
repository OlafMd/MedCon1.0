UPDATE 
	res_bld_outdoorfacility_accessroadtypes
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	AccessRoadType_Name_DictID=@AccessRoadType_Name,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_BLD_OutdoorFacility_AccessRoadTypeID = @RES_BLD_OutdoorFacility_AccessRoadTypeID