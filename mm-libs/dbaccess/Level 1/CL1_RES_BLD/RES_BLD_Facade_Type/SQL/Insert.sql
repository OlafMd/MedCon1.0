INSERT INTO 
	res_bld_facade_types
	(
		RES_BLD_Facade_TypeID,
		FacadeType_Name_DictID,
		FacadeType_Description_DictID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@RES_BLD_Facade_TypeID,
		@FacadeType_Name,
		@FacadeType_Description,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)