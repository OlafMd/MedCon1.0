INSERT INTO 
	res_dud_revisiongroup
	(
		RES_DUD_Revision_GroupID,
		RealestateProperty_RefID,
		RevisionGroup_Name,
		RevisionGroup_SubmittedBy_Account_RefID,
		RevisionGroup_Comment,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@RES_DUD_Revision_GroupID,
		@RealestateProperty_RefID,
		@RevisionGroup_Name,
		@RevisionGroup_SubmittedBy_Account_RefID,
		@RevisionGroup_Comment,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)