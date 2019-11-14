UPDATE 
	imo_questionnaire_statusgroups
SET 
	GroupLabel_DictID=@GroupLabel,
	SequenceNumber=@SequenceNumber,
	QuestionnaireVersion_RefID=@QuestionnaireVersion_RefID,
	CopyOf_PreviouslyPublishedVersion_RefID=@CopyOf_PreviouslyPublishedVersion_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	IMO_Questionnaire_StatusGroupID = @IMO_Questionnaire_StatusGroupID