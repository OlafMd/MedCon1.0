UPDATE 
	cmn_per_religions
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	Religion_Name_DictID=@Religion_Name,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_PER_ReligionID = @CMN_PER_ReligionID