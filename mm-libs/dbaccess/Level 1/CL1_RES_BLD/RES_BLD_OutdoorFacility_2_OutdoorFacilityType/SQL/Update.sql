UPDATE 
	res_bld_outdoorfacility_2_outdoorfacilitytype
SET 
	RES_BLD_OutdoorFacility_RefID=@RES_BLD_OutdoorFacility_RefID,
	RES_BLD_OutdoorFacility_Type_RefID=@RES_BLD_OutdoorFacility_Type_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID