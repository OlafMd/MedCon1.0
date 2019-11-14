UPDATE 
	imo_questionnaire_actions
SET 
	Unit_RefID=@Unit_RefID,
	Unit_Cost=@Unit_Cost,
	Unit_Amount=@Unit_Amount,
	Label_DictID=@Label,
	Description_DictID=@Description,
	CopyOf_PreviouslyPublishedVersion_RefID=@CopyOf_PreviouslyPublishedVersion_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	IMO_Questionnaire_ActionID = @IMO_Questionnaire_ActionID