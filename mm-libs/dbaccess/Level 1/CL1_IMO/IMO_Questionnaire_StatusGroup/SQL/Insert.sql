INSERT INTO 
	imo_questionnaire_statusgroups
	(
		IMO_Questionnaire_StatusGroupID,
		GroupLabel_DictID,
		SequenceNumber,
		QuestionnaireVersion_RefID,
		CopyOf_PreviouslyPublishedVersion_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@IMO_Questionnaire_StatusGroupID,
		@GroupLabel,
		@SequenceNumber,
		@QuestionnaireVersion_RefID,
		@CopyOf_PreviouslyPublishedVersion_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)