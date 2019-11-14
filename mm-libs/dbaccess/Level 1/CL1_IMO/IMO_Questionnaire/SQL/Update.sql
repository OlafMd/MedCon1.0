UPDATE 
	imo_questionnaire
SET 
	QuestionnaireName_DictID=@QuestionnaireName,
	QuestionnaireDescription_DictID=@QuestionnaireDescription,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	IMO_QuestionnaireID = @IMO_QuestionnaireID