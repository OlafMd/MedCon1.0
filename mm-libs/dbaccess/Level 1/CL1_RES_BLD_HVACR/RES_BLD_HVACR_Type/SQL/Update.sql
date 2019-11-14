UPDATE 
	res_bld_hvacr_types
SET 
	HVACRType_Name_DictID=@HVACRType_Name,
	HVACRType_Description_DictID=@HVACRType_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_BLD_HVACR_TypeID = @RES_BLD_HVACR_TypeID