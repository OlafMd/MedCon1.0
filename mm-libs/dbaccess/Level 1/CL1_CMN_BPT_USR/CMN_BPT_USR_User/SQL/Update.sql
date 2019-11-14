UPDATE 
	cmn_bpt_usr_users
SET 
	BusinessParticipant_RefID=@BusinessParticipant_RefID,
	Username=@Username,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_BPT_USR_UserID = @CMN_BPT_USR_UserID