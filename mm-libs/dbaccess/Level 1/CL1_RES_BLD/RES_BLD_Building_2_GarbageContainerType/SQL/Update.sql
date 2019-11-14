UPDATE 
	res_bld_building_2_garbagecontainertype
SET 
	RES_BLD_Building_RefID=@RES_BLD_Building_RefID,
	RES_BLD_GarbageContainerType_RefID=@RES_BLD_GarbageContainerType_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID