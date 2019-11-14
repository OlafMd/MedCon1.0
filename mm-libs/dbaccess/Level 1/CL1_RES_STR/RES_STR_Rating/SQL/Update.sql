UPDATE 
	res_str_ratings
SET 
	RatingGroup_RefID=@RatingGroup_RefID,
	Rating_Name_DictID=@Rating_Name,
	Rating_Description_DictID=@Rating_Description,
	Rating_OrdinalPosition=@Rating_OrdinalPosition,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_STR_RatingID = @RES_STR_RatingID