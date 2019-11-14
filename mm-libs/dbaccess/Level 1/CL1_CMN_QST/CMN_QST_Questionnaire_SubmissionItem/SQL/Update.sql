UPDATE 
	cmn_qst_questionnaire_submissionitems
SET 
	Questionnaire_Submission_RefID=@Questionnaire_Submission_RefID,
	Questionnaire_QuestionItem_RefID=@Questionnaire_QuestionItem_RefID,
	IsAnswerEnum_EnumerationValue_RefID=@IsAnswerEnum_EnumerationValue_RefID,
	IsAnswerStandard_Text=@IsAnswerStandard_Text,
	IsAswer_Specified=@IsAswer_Specified,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_QST_Questionnaire_SubmissionItemID = @CMN_QST_Questionnaire_SubmissionItemID