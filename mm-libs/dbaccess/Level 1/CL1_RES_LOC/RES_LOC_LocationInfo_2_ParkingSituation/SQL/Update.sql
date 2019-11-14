UPDATE 
	res_loc_locationinfo_2_parkingsituation
SET 
	RES_LOC_LocationInfo_RefID=@RES_LOC_LocationInfo_RefID,
	RES_LOC_ParkingSituation_RefID=@RES_LOC_ParkingSituation_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID