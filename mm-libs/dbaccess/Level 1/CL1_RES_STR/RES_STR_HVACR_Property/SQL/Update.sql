UPDATE 
	res_str_hvacr_properties
SET 
	HVACRProperty_Name_DictID=@HVACRProperty_Name,
	HVACRProperty_Description_DictID=@HVACRProperty_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_STR_HVACR_PropertyID = @RES_STR_HVACR_PropertyID