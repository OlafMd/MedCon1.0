UPDATE 
	cmn_per_personinfo_2_account
SET 
	CMN_PER_PersonInfo_RefID=@CMN_PER_PersonInfo_RefID,
	USR_Account_RefID=@USR_Account_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID