INSERT INTO 
	res_bld_garbagecontainertypes
	(
		RES_BLD_GarbageContainerTypeID,
		GarbageContainerType_Name_DictID,
		GarbageContainerType_Description_DictID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@RES_BLD_GarbageContainerTypeID,
		@GarbageContainerType_Name,
		@GarbageContainerType_Description,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)