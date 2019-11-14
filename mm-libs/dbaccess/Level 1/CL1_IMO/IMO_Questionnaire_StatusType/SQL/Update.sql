UPDATE 
	imo_questionnaire_statustypes
SET 
	Label_DictID=@Label,
	Description_DictID=@Description,
	Questionnaire_StatusGroup_RefID=@Questionnaire_StatusGroup_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	IMO_Questionnaire_StatusTypeID = @IMO_Questionnaire_StatusTypeID