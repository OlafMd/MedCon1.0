UPDATE 
	cmn_qst_questionnaire_submissions
SET 
	Questionnaire_Template_Version_RefID=@Questionnaire_Template_Version_RefID,
	SubmittedBy_Account_RefID=@SubmittedBy_Account_RefID,
	SubmittedOn_Date=@SubmittedOn_Date,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_QST_Questionnaire_SubmissionID = @CMN_QST_Questionnaire_SubmissionID