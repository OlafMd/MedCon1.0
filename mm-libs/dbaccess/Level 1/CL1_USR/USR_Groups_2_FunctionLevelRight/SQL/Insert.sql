INSERT INTO 
	usr_groups_2_functionlevelright
	(
		AssignmentID,
		USR_Account_FunctionLevelRight_RefID,
		USR_Group_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@AssignmentID,
		@USR_Account_FunctionLevelRight_RefID,
		@USR_Group_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)