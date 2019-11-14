UPDATE 
	res_bld_garbagecontainertypes
SET 
	GarbageContainerType_Name_DictID=@GarbageContainerType_Name,
	GarbageContainerType_Description_DictID=@GarbageContainerType_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_BLD_GarbageContainerTypeID = @RES_BLD_GarbageContainerTypeID