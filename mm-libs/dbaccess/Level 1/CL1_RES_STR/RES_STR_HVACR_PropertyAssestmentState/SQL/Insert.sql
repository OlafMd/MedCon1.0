INSERT INTO 
	res_str_hvacr_propertyassestmentstates
	(
		RES_STR_HVACR_PropertyAssestmentStateID,
		HVACRPropertyAssessmentState_Name_DictID,
		HVACRPropertyAssessmentState_Description_DictID,
		HVACRPropertyAssessmentState_OrdinalPosition,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@RES_STR_HVACR_PropertyAssestmentStateID,
		@HVACRPropertyAssessmentState_Name,
		@HVACRPropertyAssessmentState_Description,
		@HVACRPropertyAssessmentState_OrdinalPosition,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)