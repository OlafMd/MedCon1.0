UPDATE 
	res_bld_basement_floortypes
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	FloorType_Name_DictID=@FloorType_Name,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_BLD_Basement_FloorTypeID = @RES_BLD_Basement_FloorTypeID