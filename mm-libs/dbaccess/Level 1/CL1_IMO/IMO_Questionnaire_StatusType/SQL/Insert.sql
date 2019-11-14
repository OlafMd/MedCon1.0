INSERT INTO 
	imo_questionnaire_statustypes
	(
		IMO_Questionnaire_StatusTypeID,
		Label_DictID,
		Description_DictID,
		Questionnaire_StatusGroup_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@IMO_Questionnaire_StatusTypeID,
		@Label,
		@Description,
		@Questionnaire_StatusGroup_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)