UPDATE 
	res_str_roof_properties
SET 
	RoofProperty_Name_DictID=@RoofProperty_Name,
	RoofProperty_Description_DictID=@RoofProperty_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_STR_Roof_PropertyID = @RES_STR_Roof_PropertyID