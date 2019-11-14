UPDATE 
	cmn_bpt_usr_user_passwords
SET 
	CMN_BPT_USR_User_RefID=@CMN_BPT_USR_User_RefID,
	IsActive=@IsActive,
	Password_Hash=@Password_Hash,
	Password_Salt=@Password_Salt,
	Password_Algorithm=@Password_Algorithm,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_BPT_USR_User_PasswordID = @CMN_BPT_USR_User_PasswordID