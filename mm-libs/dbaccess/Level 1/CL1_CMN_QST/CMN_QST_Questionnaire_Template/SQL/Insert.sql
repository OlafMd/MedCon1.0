INSERT INTO 
	cmn_qst_questionnaire_templates
	(
		CMN_QST_Questionnaire_TemplateID,
		QuestionnaireTemplate_Name_DictID,
		QuestionnaireTemplate_Description_DictID,
		Current_PublishedVersion_RefID,
		Current_UnpublishedVersion_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_QST_Questionnaire_TemplateID,
		@QuestionnaireTemplate_Name,
		@QuestionnaireTemplate_Description,
		@Current_PublishedVersion_RefID,
		@Current_UnpublishedVersion_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)