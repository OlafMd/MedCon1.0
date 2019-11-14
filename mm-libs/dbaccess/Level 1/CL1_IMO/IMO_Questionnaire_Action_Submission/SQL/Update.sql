UPDATE 
	imo_questionnaire_action_submissions
SET 
	Questionnaire_Action_RefID=@Questionnaire_Action_RefID,
	Questionnaire_CustomAction_RefID=@Questionnaire_CustomAction_RefID,
	Questionnaire_Submission_RefID=@Questionnaire_Submission_RefID,
	Questionnaire_ActionTimeframe_RefID=@Questionnaire_ActionTimeframe_RefID,
	Unit_Cost=@Unit_Cost,
	Unit_Amount=@Unit_Amount,
	Unit_TotalCost=@Unit_TotalCost,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	IMO_Questionnaire_Action_SubmissionID = @IMO_Questionnaire_Action_SubmissionID