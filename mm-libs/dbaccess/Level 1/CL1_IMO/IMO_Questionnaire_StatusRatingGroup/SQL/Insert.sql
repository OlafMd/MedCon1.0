INSERT INTO 
	imo_questionnaire_statusratinggroups
	(
		IMO_Questionnaire_StatusRatingGroupID,
		Label_DictID,
		CopyOf_PreviouslyPublishedVersion_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@IMO_Questionnaire_StatusRatingGroupID,
		@Label,
		@CopyOf_PreviouslyPublishedVersion_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)