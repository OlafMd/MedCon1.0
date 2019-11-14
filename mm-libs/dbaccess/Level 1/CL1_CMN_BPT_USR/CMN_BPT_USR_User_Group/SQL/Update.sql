UPDATE 
	cmn_bpt_usr_user_groups
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	UserGroup_Name_DictID=@UserGroup_Name,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_BPT_USR_User_GroupID = @CMN_BPT_USR_User_GroupID