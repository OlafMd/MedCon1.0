UPDATE 
	res_str_hvacrs
SET 
	DUD_Revision_RefID=@DUD_Revision_RefID,
	RES_BLD_HVACR_RefID=@RES_BLD_HVACR_RefID,
	AverageRating_RefID=@AverageRating_RefID,
	DocumentHeader_RefID=@DocumentHeader_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_STR_HVACRID = @RES_STR_HVACRID