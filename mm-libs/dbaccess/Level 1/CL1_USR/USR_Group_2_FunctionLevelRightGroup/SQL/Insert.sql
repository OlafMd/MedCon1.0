INSERT INTO 
	usr_group_2_functionlevelrightgroup
	(
		AssignmentID,
		USR_Account_FunctionLevelRightGroup_RefID,
		USR_Group_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@AssignmentID,
		@USR_Account_FunctionLevelRightGroup_RefID,
		@USR_Group_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)