INSERT INTO 
	imo_questionnaireversions
	(
		IMO_QuestionnaireVersionID,
		DefaultCurrency_RefID,
		Questionnaire_RefID,
		IsPersisted,
		ActionTimeframeGroup_RefID,
		CustomStatusQuestionGroup_RefID,
		VersionDescription,
		VersionNumber,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@IMO_QuestionnaireVersionID,
		@DefaultCurrency_RefID,
		@Questionnaire_RefID,
		@IsPersisted,
		@ActionTimeframeGroup_RefID,
		@CustomStatusQuestionGroup_RefID,
		@VersionDescription,
		@VersionNumber,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)