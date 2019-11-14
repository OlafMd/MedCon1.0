UPDATE 
	res_str_ratinggroups
SET 
	RatingGroup_Name_DictID=@RatingGroup_Name,
	RatingGroup_Description_DictID=@RatingGroup_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_STR_RatingGroupID = @RES_STR_RatingGroupID