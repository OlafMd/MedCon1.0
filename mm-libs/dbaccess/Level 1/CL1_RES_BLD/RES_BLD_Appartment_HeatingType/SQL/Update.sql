UPDATE 
	res_bld_appartment_heatingtypes
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	HeatingType_Name_DictID=@HeatingType_Name,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_BLD_Appartment_HeatingTypeID = @RES_BLD_Appartment_HeatingTypeID