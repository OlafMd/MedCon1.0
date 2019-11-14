UPDATE 
	res_str_facade_properties
SET 
	FacadeProperty_Name_DictID=@FacadeProperty_Name,
	FacadeProperty_Description_DictID=@FacadeProperty_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_STR_Facade_PropertyID = @RES_STR_Facade_PropertyID