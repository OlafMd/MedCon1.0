INSERT INTO 
	res_str_outdoorfacility_propertyassestmentstates
	(
		RES_STR_OutdoorFacility_PropertyAssestmentStateID,
		OutdoorFacilityPropertyAssessmentState_Name_DictID,
		OutdoorFacilityPropertyAssessmentState_Description_DictID,
		OutdoorFacilityPropertyAssessmentState_OrdinalPosition,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@RES_STR_OutdoorFacility_PropertyAssestmentStateID,
		@OutdoorFacilityPropertyAssessmentState_Name,
		@OutdoorFacilityPropertyAssessmentState_Description,
		@OutdoorFacilityPropertyAssessmentState_OrdinalPosition,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)