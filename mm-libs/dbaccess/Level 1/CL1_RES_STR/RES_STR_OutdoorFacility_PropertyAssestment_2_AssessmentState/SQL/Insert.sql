INSERT INTO 
	res_str_outdoorfacility_propertyassestment_2_assessmentstate
	(
		AssignmentID,
		RES_STR_OutdoorFacility_PropertyAssessment_RefID,
		RES_STR_OutdoorFacility_PropertyAssessmentState_RefID,
		Comment,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@AssignmentID,
		@RES_STR_OutdoorFacility_PropertyAssessment_RefID,
		@RES_STR_OutdoorFacility_PropertyAssessmentState_RefID,
		@Comment,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)