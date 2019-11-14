UPDATE 
	cmn_numberrange_usageareas
SET 
	GlobalStaticMatchingID=@GlobalStaticMatchingID,
	UsageArea_Name_DictID=@UsageArea_Name,
	UsageArea_Description_DictID=@UsageArea_Description,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_NumberRange_UsageAreaID = @CMN_NumberRange_UsageAreaID