UPDATE 
	res_str_basement_propertyassestment_2_assessmentstate
SET 
	RES_STR_Basement_PropertyAssessment_RefID=@RES_STR_Basement_PropertyAssessment_RefID,
	RES_STR_Basement_PropertyAssessmentState_RefID=@RES_STR_Basement_PropertyAssessmentState_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID