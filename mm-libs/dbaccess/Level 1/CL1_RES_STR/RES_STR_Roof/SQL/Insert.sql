INSERT INTO 
	res_str_roofs
	(
		RES_STR_RoofID,
		DUD_Revision_RefID,
		RES_BLD_Roof_RefID,
		AverageRating_RefID,
		DocumentHeader_RefID,
		Comment,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@RES_STR_RoofID,
		@DUD_Revision_RefID,
		@RES_BLD_Roof_RefID,
		@AverageRating_RefID,
		@DocumentHeader_RefID,
		@Comment,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)