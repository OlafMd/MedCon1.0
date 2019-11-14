INSERT INTO 
	res_bld_building_revisionheaders
	(
		RES_BLD_Building_RevisionHeaderID,
		CurrentBuildingVersion_RefID,
		RealestateProperty_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@RES_BLD_Building_RevisionHeaderID,
		@CurrentBuildingVersion_RefID,
		@RealestateProperty_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)