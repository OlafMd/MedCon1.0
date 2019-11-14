UPDATE 
	imo_questionnaire_2_questionnaire_statusgroup
SET 
	QuestionnaireVersion_RefID=@QuestionnaireVersion_RefID,
	Questionnaire_StatusGroup_RefID=@Questionnaire_StatusGroup_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID