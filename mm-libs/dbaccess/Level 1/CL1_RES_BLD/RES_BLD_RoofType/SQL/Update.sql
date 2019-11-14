UPDATE 
	res_bld_rooftype
SET 
	RoofType_Name_DictID=@RoofType_Name,
	RoofType_Dictionary_DictID=@RoofType_Dictionary,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_BLD_RoofTypeID = @RES_BLD_RoofTypeID