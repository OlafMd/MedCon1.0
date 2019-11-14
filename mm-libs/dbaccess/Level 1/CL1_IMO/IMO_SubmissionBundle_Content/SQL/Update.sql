UPDATE 
	imo_submissionbundle_contents
SET 
	Questionnaire_SubmissionBinder_RefID=@Questionnaire_SubmissionBinder_RefID,
	SubmissionBundle_RefID=@SubmissionBundle_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	IMO_SubmissionBundle_ContentID = @IMO_SubmissionBundle_ContentID