UPDATE 
	res_loc_locationinformation_2_neighborhoodquality
SET 
	RES_LOC_LocationInformation_RefID=@RES_LOC_LocationInformation_RefID,
	RES_LOC_NeighborhoodQuality_RefID=@RES_LOC_NeighborhoodQuality_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID