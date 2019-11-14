UPDATE 
	imo_questionnaire_actiontimeframegroups
SET 
	Label_DictID=@Label,
	CopyOf_PreviouslyPublishedVersion_RefID=@CopyOf_PreviouslyPublishedVersion_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	IMO_Questionnaire_ActionTimeframeGroupID = @IMO_Questionnaire_ActionTimeframeGroupID