UPDATE 
	res_qst_questionnaire
SET 
	Questionnaire_Name_DictID=@Questionnaire_Name,
	Questionnaire_Description_DictID=@Questionnaire_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID,
	Current_QuestionnaireVersion_RefID=@Current_QuestionnaireVersion_RefID
WHERE 
	RES_QST_QuestionnaireID = @RES_QST_QuestionnaireID