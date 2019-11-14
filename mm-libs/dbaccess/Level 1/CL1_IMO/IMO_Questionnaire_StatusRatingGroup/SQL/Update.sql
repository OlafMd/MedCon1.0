UPDATE 
	imo_questionnaire_statusratinggroups
SET 
	Label_DictID=@Label,
	CopyOf_PreviouslyPublishedVersion_RefID=@CopyOf_PreviouslyPublishedVersion_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	IMO_Questionnaire_StatusRatingGroupID = @IMO_Questionnaire_StatusRatingGroupID