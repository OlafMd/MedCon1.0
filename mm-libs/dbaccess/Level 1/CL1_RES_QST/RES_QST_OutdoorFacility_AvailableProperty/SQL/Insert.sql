INSERT INTO 
	res_qst_outdoorfacility_availableproperties
	(
		RES_QST_OutdoorFacility_AvailablePropertyID,
		RES_QST_Questionnaire_Version_RefID,
		RES_STR_OutdoorFacility_Property_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@RES_QST_OutdoorFacility_AvailablePropertyID,
		@RES_QST_Questionnaire_Version_RefID,
		@RES_STR_OutdoorFacility_Property_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)