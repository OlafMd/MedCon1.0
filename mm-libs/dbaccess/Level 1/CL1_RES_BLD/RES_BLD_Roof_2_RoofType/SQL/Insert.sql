INSERT INTO 
	res_bld_roof_2_rooftype
	(
		AssignmentID,
		RES_BLD_Roof_RefID,
		RES_BLD_Roof_Type_RefID,
		Comment,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@AssignmentID,
		@RES_BLD_Roof_RefID,
		@RES_BLD_Roof_Type_RefID,
		@Comment,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)