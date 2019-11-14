UPDATE 
	imo_questionnaire_image_submissions
SET 
	ImageGroup_RefID=@ImageGroup_RefID,
	DocumentManagement_ServerURL=@DocumentManagement_ServerURL,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	IMO_Questionnaire_Image_SubmissionID = @IMO_Questionnaire_Image_SubmissionID