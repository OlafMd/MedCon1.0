UPDATE 
	imo_questionnaire_status_submissions
SET 
	Questionnaire_Submission_RefID=@Questionnaire_Submission_RefID,
	Questionnaire_StatusRating_RefID=@Questionnaire_StatusRating_RefID,
	Questionnaire_Status_RefID=@Questionnaire_Status_RefID,
	Comment=@Comment,
	ImageGroup_RefID=@ImageGroup_RefID,
	IsStatusApplicable=@IsStatusApplicable,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	IMO_Questionnaire_Status_SubmissionID = @IMO_Questionnaire_Status_SubmissionID