UPDATE 
	res_bld_facade_types
SET 
	FacadeType_Name_DictID=@FacadeType_Name,
	FacadeType_Description_DictID=@FacadeType_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_BLD_Facade_TypeID = @RES_BLD_Facade_TypeID