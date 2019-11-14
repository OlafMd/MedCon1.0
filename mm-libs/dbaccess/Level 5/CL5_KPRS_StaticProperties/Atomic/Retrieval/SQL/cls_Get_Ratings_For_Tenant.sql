
	Select
	  res_str_ratings.RES_STR_RatingID,
	  res_str_ratings.RatingGroup_RefID,
	  res_str_ratings.Rating_Name_DictID,
	  res_str_ratings.Rating_Description_DictID,
	  res_str_ratings.Rating_OrdinalPosition
	From
	  res_str_ratings
	Where
	  res_str_ratings.IsDeleted = 0 And
	  res_str_ratings.Tenant_RefID = @TenantID
  