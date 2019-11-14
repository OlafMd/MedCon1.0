INSERT INTO 
	res_str_hvacrs
	(
		RES_STR_HVACRID,
		DUD_Revision_RefID,
		RES_BLD_HVACR_RefID,
		AverageRating_RefID,
		DocumentHeader_RefID,
		Comment,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@RES_STR_HVACRID,
		@DUD_Revision_RefID,
		@RES_BLD_HVACR_RefID,
		@AverageRating_RefID,
		@DocumentHeader_RefID,
		@Comment,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)