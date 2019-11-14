INSERT INTO 
	res_bld_attics
	(
		RES_BLD_AtticID,
		Building_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@RES_BLD_AtticID,
		@Building_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)