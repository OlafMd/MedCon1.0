INSERT INTO 
	imo_questionnaire_imagegroup_submissions
	(
		IMO_Questionnaire_ImageGroup_SubmissionID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@IMO_Questionnaire_ImageGroup_SubmissionID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)