INSERT INTO 
	res_bld_building_2_garbagecontainertype
	(
		AssignmentID,
		RES_BLD_Building_RefID,
		RES_BLD_GarbageContainerType_RefID,
		Comment,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@AssignmentID,
		@RES_BLD_Building_RefID,
		@RES_BLD_GarbageContainerType_RefID,
		@Comment,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)