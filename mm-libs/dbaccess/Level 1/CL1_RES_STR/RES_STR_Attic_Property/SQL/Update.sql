UPDATE 
	res_str_attic_properties
SET 
	AtticProperty_Name_DictID=@AtticProperty_Name,
	AtticProperty_Description_DictID=@AtticProperty_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_STR_Attic_PropertyID = @RES_STR_Attic_PropertyID