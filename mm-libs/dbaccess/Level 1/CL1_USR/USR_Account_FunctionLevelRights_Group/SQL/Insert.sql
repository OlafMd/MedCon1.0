INSERT INTO 
	usr_account_functionlevelrights_groups
	(
		USR_Account_FunctionLevelRights_GroupID,
		GlobalPropertyMatchingID,
		Label,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@USR_Account_FunctionLevelRights_GroupID,
		@GlobalPropertyMatchingID,
		@Label,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)