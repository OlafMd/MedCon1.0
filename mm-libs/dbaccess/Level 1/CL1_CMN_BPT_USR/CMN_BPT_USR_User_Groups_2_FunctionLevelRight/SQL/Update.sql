UPDATE 
	cmn_bpt_usr_user_groups_2_functionlevelrights
SET 
	CMN_BPT_USR_User_Group_RefID=@CMN_BPT_USR_User_Group_RefID,
	CMN_BPT_USR_User_FunctionLevelRight_RefID=@CMN_BPT_USR_User_FunctionLevelRight_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	AssignmentID = @AssignmentID