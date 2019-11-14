UPDATE 
	cmn_str_professions
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	ProfessionSimpleName=@ProfessionSimpleName,
	ProfessionName_DictID=@ProfessionName,
	ProfessionDescription_DictID=@ProfessionDescription,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_STR_ProfessionID = @CMN_STR_ProfessionID