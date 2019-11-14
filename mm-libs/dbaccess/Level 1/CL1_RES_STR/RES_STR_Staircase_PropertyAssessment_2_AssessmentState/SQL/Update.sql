UPDATE 
	res_str_staircase_propertyassessment_2_assessmentstate
SET 
	RES_STR_Staircase_PropertyAssessmentState_RefID=@RES_STR_Staircase_PropertyAssessmentState_RefID,
	RES_STR_Staircase_PropertyAssessment_RefID=@RES_STR_Staircase_PropertyAssessment_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID