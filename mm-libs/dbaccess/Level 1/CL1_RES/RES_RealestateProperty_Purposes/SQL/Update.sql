UPDATE 
	res_realestateproperty_purposes
SET 
	Purpose_Name_DictID=@Purpose_Name,
	Purpose_Description_DictID=@Purpose_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_RealestateProperty_PurposeID = @RES_RealestateProperty_PurposeID