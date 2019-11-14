UPDATE 
	res_realestateproperty_types
SET 
	RealestatePropertyType_Name_DictID=@RealestatePropertyType_Name,
	RealestatePropertyType_Description_DictID=@RealestatePropertyType_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_RealestateProperty_TypeID = @RES_RealestateProperty_TypeID