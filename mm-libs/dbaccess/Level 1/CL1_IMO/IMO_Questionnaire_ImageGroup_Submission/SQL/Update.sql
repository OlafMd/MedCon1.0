UPDATE 
	imo_questionnaire_imagegroup_submissions
SET 
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	IMO_Questionnaire_ImageGroup_SubmissionID = @IMO_Questionnaire_ImageGroup_SubmissionID