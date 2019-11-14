UPDATE 
	res_str_roofs
SET 
	DUD_Revision_RefID=@DUD_Revision_RefID,
	RES_BLD_Roof_RefID=@RES_BLD_Roof_RefID,
	AverageRating_RefID=@AverageRating_RefID,
	DocumentHeader_RefID=@DocumentHeader_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_STR_RoofID = @RES_STR_RoofID