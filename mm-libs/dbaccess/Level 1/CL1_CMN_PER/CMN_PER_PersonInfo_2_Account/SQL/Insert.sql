INSERT INTO 
	cmn_per_personinfo_2_account
	(
		AssignmentID,
		CMN_PER_PersonInfo_RefID,
		USR_Account_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@AssignmentID,
		@CMN_PER_PersonInfo_RefID,
		@USR_Account_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)