INSERT INTO 
	imo_submissionbundle_contents
	(
		IMO_SubmissionBundle_ContentID,
		Questionnaire_SubmissionBinder_RefID,
		SubmissionBundle_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@IMO_SubmissionBundle_ContentID,
		@Questionnaire_SubmissionBinder_RefID,
		@SubmissionBundle_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)