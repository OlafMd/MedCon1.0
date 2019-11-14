UPDATE 
	res_bld_appartment_wallcoveringtypes
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	WallCoveringType_Name_DictID=@WallCoveringType_Name,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_BLD_Appartment_WallCoveringTypeID = @RES_BLD_Appartment_WallCoveringTypeID