UPDATE 
	res_str_staircase_properties
SET 
	StaircaseProperty_Name_DictID=@StaircaseProperty_Name,
	StaircaseProperty_Description_DictID=@StaircaseProperty_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_STR_Staircase_PropertyID = @RES_STR_Staircase_PropertyID