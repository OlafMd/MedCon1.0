UPDATE 
	res_bld_building_revisionheaders
SET 
	CurrentBuildingVersion_RefID=@CurrentBuildingVersion_RefID,
	RealestateProperty_RefID=@RealestateProperty_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_BLD_Building_RevisionHeaderID = @RES_BLD_Building_RevisionHeaderID