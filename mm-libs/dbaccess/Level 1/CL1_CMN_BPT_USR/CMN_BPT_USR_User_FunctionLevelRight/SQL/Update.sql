UPDATE 
	cmn_bpt_usr_user_functionlevelrights
SET 
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_BPT_USR_User_FunctionLevelRightID = @CMN_BPT_USR_User_FunctionLevelRightID