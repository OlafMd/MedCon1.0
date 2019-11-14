INSERT INTO 
	res_bld_hvacrs
	(
		RES_BLD_HVACRID,
		Building_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@RES_BLD_HVACRID,
		@Building_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)