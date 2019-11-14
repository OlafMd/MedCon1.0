UPDATE 
	imo_questionnaire_statuses
SET 
	Questionnaire_StatusGroup_RefID=@Questionnaire_StatusGroup_RefID,
	Parent_RefID=@Parent_RefID,
	Label_DictID=@Label,
	SequenceNumber=@SequenceNumber,
	Questionnaire_StatusRatingGroup_RefID=@Questionnaire_StatusRatingGroup_RefID,
	CopyOf_PreviouslyPublishedVersion_RefID=@CopyOf_PreviouslyPublishedVersion_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	IMO_Questionnaire_StatusID = @IMO_Questionnaire_StatusID