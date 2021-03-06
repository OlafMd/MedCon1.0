INSERT INTO 
	res_str_staircases
	(
		RES_STR_StaircaseID,
		DUD_Revision_RefID,
		RES_BLD_Staircase_RefID,
		AverageRating_RefID,
		DocumentHeader_RefID,
		Comment,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@RES_STR_StaircaseID,
		@DUD_Revision_RefID,
		@RES_BLD_Staircase_RefID,
		@AverageRating_RefID,
		@DocumentHeader_RefID,
		@Comment,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)