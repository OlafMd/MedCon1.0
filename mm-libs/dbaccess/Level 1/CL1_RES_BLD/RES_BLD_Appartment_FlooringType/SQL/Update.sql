UPDATE 
	res_bld_appartment_flooringtypes
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	FlooringType_Name_DictID=@FlooringType_Name,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_BLD_Appartment_FlooringTypesID = @RES_BLD_Appartment_FlooringTypesID