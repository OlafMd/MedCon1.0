INSERT INTO 
	res_str_staircase_propertyassessment_2_assessmentstate
	(
		AssignmentID,
		RES_STR_Staircase_PropertyAssessmentState_RefID,
		RES_STR_Staircase_PropertyAssessment_RefID,
		Comment,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@AssignmentID,
		@RES_STR_Staircase_PropertyAssessmentState_RefID,
		@RES_STR_Staircase_PropertyAssessment_RefID,
		@Comment,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)