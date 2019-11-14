UPDATE 
	imo_questionnaire_action_timeframes
SET 
	ActionTimeframeGroup_RefID=@ActionTimeframeGroup_RefID,
	Label_DictID=@Label,
	Description_DictID=@Description,
	SequenceNumber=@SequenceNumber,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	IMO_Questionnaire_Action_TimeframeID = @IMO_Questionnaire_Action_TimeframeID