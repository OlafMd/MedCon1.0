UPDATE 
	usr_account_functionlevelrights
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	FunctionLevelRights_Group_RefID=@FunctionLevelRights_Group_RefID,
	RightName=@RightName,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	USR_Account_FunctionLevelRightID = @USR_Account_FunctionLevelRightID