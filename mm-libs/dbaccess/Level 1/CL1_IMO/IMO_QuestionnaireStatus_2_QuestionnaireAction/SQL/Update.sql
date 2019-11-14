UPDATE 
	imo_questionnairestatus_2_questionnaireaction
SET 
	QuestionnaireAction_RefID=@QuestionnaireAction_RefID,
	QuestionnaireStatus_RefID=@QuestionnaireStatus_RefID,
	Default_Timeframe_RefID=@Default_Timeframe_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID