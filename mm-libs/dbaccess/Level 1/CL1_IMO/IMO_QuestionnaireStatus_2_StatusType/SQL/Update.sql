UPDATE 
	imo_questionnairestatus_2_statustype
SET 
	Questionnaire_StatusType_RefID=@Questionnaire_StatusType_RefID,
	Questionnaire_Status_RefID=@Questionnaire_Status_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID