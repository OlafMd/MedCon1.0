UPDATE 
	res_loc_neighborhoodqualities
SET 
	NeighborhoodQuality_Name_DictID=@NeighborhoodQuality_Name,
	NeighborhoodQuality_Description_DictID=@NeighborhoodQuality_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_LOC_NeighborhoodQualityID = @RES_LOC_NeighborhoodQualityID