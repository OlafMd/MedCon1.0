INSERT INTO 
	res_bld_hvacr_types
	(
		RES_BLD_HVACR_TypeID,
		HVACRType_Name_DictID,
		HVACRType_Description_DictID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@RES_BLD_HVACR_TypeID,
		@HVACRType_Name,
		@HVACRType_Description,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)