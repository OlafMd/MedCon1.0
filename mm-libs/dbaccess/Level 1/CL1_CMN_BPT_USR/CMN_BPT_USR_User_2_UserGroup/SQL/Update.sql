UPDATE 
	cmn_bpt_usr_user_2_usergroups
SET 
	CMN_BPT_USR_User_RefID=@CMN_BPT_USR_User_RefID,
	CMN_BPT_USR_UserGroup_RefID=@CMN_BPT_USR_UserGroup_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	AssignmentID = @AssignmentID