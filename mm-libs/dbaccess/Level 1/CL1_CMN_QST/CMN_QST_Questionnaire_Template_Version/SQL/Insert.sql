INSERT INTO 
	cmn_qst_questionnaire_template_versions
	(
		CMN_QST_Questionnaire_Template_VersionID,
		QuestionnaireTemplate_RefID,
		CopiedFrom_TemplateVersion_RefID,
		QuestionnaireTemplateVersion_VersionNumber,
		QuestionnaireTemplateVersion_VersionComment,
		IsQuestionnaireVersion_Published,
		Creation_Account_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_QST_Questionnaire_Template_VersionID,
		@QuestionnaireTemplate_RefID,
		@CopiedFrom_TemplateVersion_RefID,
		@QuestionnaireTemplateVersion_VersionNumber,
		@QuestionnaireTemplateVersion_VersionComment,
		@IsQuestionnaireVersion_Published,
		@Creation_Account_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)