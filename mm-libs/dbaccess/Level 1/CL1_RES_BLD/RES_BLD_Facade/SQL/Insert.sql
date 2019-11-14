INSERT INTO 
	res_bld_facades
	(
		RES_BLD_FacadeID,
		Building_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@RES_BLD_FacadeID,
		@Building_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)