UPDATE 
	cmn_bpt_usr_user_2_functionlevelright
SET 
	CMN_BPT_USR_User_RefID=@CMN_BPT_USR_User_RefID,
	CMN_BPT_USR_User_2_FunctionLevelRight_RefID=@CMN_BPT_USR_User_2_FunctionLevelRight_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	AssignmentID = @AssignmentID