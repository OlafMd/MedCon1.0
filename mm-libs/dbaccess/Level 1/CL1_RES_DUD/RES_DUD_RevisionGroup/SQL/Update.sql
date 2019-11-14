UPDATE 
	res_dud_revisiongroup
SET 
	RealestateProperty_RefID=@RealestateProperty_RefID,
	RevisionGroup_Name=@RevisionGroup_Name,
	RevisionGroup_SubmittedBy_Account_RefID=@RevisionGroup_SubmittedBy_Account_RefID,
	RevisionGroup_Comment=@RevisionGroup_Comment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_DUD_Revision_GroupID = @RES_DUD_Revision_GroupID