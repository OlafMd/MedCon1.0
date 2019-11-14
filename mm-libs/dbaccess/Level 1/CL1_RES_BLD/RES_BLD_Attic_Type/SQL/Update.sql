UPDATE 
	res_bld_attic_types
SET 
	AtticType_Name_DictID=@AtticType_Name,
	AtticType_Description_DictID=@AtticType_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_BLD_Attic_TypeID = @RES_BLD_Attic_TypeID