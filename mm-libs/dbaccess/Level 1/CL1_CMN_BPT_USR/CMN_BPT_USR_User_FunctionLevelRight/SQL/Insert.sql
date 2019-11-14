INSERT INTO 
	cmn_bpt_usr_user_functionlevelrights
	(
		CMN_BPT_USR_User_FunctionLevelRightID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@CMN_BPT_USR_User_FunctionLevelRightID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)