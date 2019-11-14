UPDATE 
	cmn_str_areasofbusiness
SET 
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_STR_AreaOfBusinessID = @CMN_STR_AreaOfBusinessID