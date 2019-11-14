UPDATE 
	imo_questionnaire_statusratings
SET 
	StatusRatingGroup_RefID=@StatusRatingGroup_RefID,
	Label_DictID=@Label,
	Description_DictID=@Description,
	SequenceNumber=@SequenceNumber,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	IMO_Questionnaire_StatusRatingID = @IMO_Questionnaire_StatusRatingID