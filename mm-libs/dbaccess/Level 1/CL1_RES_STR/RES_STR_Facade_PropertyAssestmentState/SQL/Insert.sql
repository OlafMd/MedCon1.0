INSERT INTO 
	res_str_facade_propertyassestmentstates
	(
		RES_STR_Facade_PropertyAssestmentStateID,
		FacadePropertyAssessmentState_Name_DictID,
		FacadePropertyAssessmentState_Description_DictID,
		FacadePropertyAssessmentState_OrdinalPosition,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@RES_STR_Facade_PropertyAssestmentStateID,
		@FacadePropertyAssessmentState_Name,
		@FacadePropertyAssessmentState_Description,
		@FacadePropertyAssessmentState_OrdinalPosition,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)