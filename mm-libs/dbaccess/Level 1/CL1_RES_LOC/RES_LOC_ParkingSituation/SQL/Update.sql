UPDATE 
	res_loc_parkingsituations
SET 
	ParkingSituation_Name_DictID=@ParkingSituation_Name,
	ParkingSituation_Description_DictID=@ParkingSituation_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_LOC_ParkingSituationID = @RES_LOC_ParkingSituationID