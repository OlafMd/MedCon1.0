UPDATE 
	imo_questionnaireversion_2_statusratinggroup
SET 
	Questionnaire_StatusRatingGroup_RefID=@Questionnaire_StatusRatingGroup_RefID,
	QuestionnaireVersion_RefID=@QuestionnaireVersion_RefID,
	IsDefault=@IsDefault,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID