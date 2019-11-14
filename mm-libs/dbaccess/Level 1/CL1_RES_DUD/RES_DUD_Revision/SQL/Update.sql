UPDATE 
	res_dud_revisions
SET 
	RevisionGroup_RefID=@RevisionGroup_RefID,
	RES_BLD_Building_RefID=@RES_BLD_Building_RefID,
	QuestionnaireVersion_RefID=@QuestionnaireVersion_RefID,
	Revision_Comment=@Revision_Comment,
	Revision_Title=@Revision_Title,
	ScopeOfInspectionIncludes_Internal=@ScopeOfInspectionIncludes_Internal,
	ScopeOfInspectionIncludes_External=@ScopeOfInspectionIncludes_External,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_DUD_RevisionID = @RES_DUD_RevisionID