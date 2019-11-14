INSERT INTO 
	rel_bld_facades
	(
		REL_BLD_FacadeID,
		Building_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@REL_BLD_FacadeID,
		@Building_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)