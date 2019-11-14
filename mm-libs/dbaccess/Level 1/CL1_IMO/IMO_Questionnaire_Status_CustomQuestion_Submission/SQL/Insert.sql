INSERT INTO 
	imo_questionnaire_status_customquestion_submissions
	(
		IMO_Questionnaire_Status_CustomQuestion_SubmissionID,
		Questionnaire_Submission_RefID,
		Questionnaire_Status_RefID,
		Questionnaire_CustomStatusQuestion_RefID,
		Value_Number,
		Value_Text,
		Value_Boolean,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@IMO_Questionnaire_Status_CustomQuestion_SubmissionID,
		@Questionnaire_Submission_RefID,
		@Questionnaire_Status_RefID,
		@Questionnaire_CustomStatusQuestion_RefID,
		@Value_Number,
		@Value_Text,
		@Value_Boolean,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)