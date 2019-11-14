UPDATE 
	res_bld_basement_types
SET 
	BasementType_Name_DictID=@BasementType_Name,
	BasementType_Description_DictID=@BasementType_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_BLD_Basement_TypeID = @RES_BLD_Basement_TypeID