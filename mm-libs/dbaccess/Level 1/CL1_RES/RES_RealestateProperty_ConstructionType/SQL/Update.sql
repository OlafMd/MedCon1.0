UPDATE 
	res_realestateproperty_constructiontypes
SET 
	ConstructionType_Name_DictID=@ConstructionType_Name,
	ConstructionType_Description_DictID=@ConstructionType_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_RealestateProperty_ConstructionTypeID = @RES_RealestateProperty_ConstructionTypeID