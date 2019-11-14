INSERT INTO 
	res_bld_roof
	(
		RES_BLD_RoofID,
		Building_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@RES_BLD_RoofID,
		@Building_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)