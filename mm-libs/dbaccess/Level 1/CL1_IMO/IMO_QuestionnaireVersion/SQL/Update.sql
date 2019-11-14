UPDATE 
	imo_questionnaireversions
SET 
	DefaultCurrency_RefID=@DefaultCurrency_RefID,
	Questionnaire_RefID=@Questionnaire_RefID,
	IsPersisted=@IsPersisted,
	ActionTimeframeGroup_RefID=@ActionTimeframeGroup_RefID,
	CustomStatusQuestionGroup_RefID=@CustomStatusQuestionGroup_RefID,
	VersionDescription=@VersionDescription,
	VersionNumber=@VersionNumber,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	IMO_QuestionnaireVersionID = @IMO_QuestionnaireVersionID