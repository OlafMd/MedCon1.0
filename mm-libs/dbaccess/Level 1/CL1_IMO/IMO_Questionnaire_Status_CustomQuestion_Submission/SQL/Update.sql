UPDATE 
	imo_questionnaire_status_customquestion_submissions
SET 
	Questionnaire_Submission_RefID=@Questionnaire_Submission_RefID,
	Questionnaire_Status_RefID=@Questionnaire_Status_RefID,
	Questionnaire_CustomStatusQuestion_RefID=@Questionnaire_CustomStatusQuestion_RefID,
	Value_Number=@Value_Number,
	Value_Text=@Value_Text,
	Value_Boolean=@Value_Boolean,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	IMO_Questionnaire_Status_CustomQuestion_SubmissionID = @IMO_Questionnaire_Status_CustomQuestion_SubmissionID