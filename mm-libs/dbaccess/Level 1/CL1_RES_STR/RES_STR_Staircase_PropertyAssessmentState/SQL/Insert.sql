INSERT INTO 
	res_str_staircase_propertyassessmentstates
	(
		RES_STR_Staircase_PropertyAssessmentStateID,
		StaircasePropertyAssessmentState_Name_DictID,
		StaircasePropertyAssessmentState_Description_DictID,
		StaircasePropertyAssessmentState_OrdinalPosition,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@RES_STR_Staircase_PropertyAssessmentStateID,
		@StaircasePropertyAssessmentState_Name,
		@StaircasePropertyAssessmentState_Description,
		@StaircasePropertyAssessmentState_OrdinalPosition,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)