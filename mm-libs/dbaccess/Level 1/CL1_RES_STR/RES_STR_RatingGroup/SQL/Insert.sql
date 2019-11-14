INSERT INTO 
	res_str_ratinggroups
	(
		RES_STR_RatingGroupID,
		RatingGroup_Name_DictID,
		RatingGroup_Description_DictID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@RES_STR_RatingGroupID,
		@RatingGroup_Name,
		@RatingGroup_Description,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)