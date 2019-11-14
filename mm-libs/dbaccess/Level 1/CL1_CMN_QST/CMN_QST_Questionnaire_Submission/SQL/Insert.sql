INSERT INTO 
	cmn_qst_questionnaire_submissions
	(
		CMN_QST_Questionnaire_SubmissionID,
		Questionnaire_Template_Version_RefID,
		SubmittedBy_Account_RefID,
		SubmittedOn_Date,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_QST_Questionnaire_SubmissionID,
		@Questionnaire_Template_Version_RefID,
		@SubmittedBy_Account_RefID,
		@SubmittedOn_Date,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)