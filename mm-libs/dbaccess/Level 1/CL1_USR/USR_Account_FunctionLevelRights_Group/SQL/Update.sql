UPDATE 
	usr_account_functionlevelrights_groups
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	Label=@Label,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	USR_Account_FunctionLevelRights_GroupID = @USR_Account_FunctionLevelRights_GroupID