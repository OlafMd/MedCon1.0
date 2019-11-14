UPDATE 
	imo_questionnaire_customstatusquestiongroups
SET 
	Label_DictID=@Label,
	CopyOf_PreviouslyPublishedVersion_RefID=@CopyOf_PreviouslyPublishedVersion_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	IMO_Questionnaire_CustomStatusQuestionGroupID = @IMO_Questionnaire_CustomStatusQuestionGroupID