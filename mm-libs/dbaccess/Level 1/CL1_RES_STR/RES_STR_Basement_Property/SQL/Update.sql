UPDATE 
	res_str_basement_properties
SET 
	BasementProperty_Name_DictID=@BasementProperty_Name,
	BasementProperty_Description_DictID=@BasementProperty_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_STR_Basement_PropertyID = @RES_STR_Basement_PropertyID