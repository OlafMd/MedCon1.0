INSERT INTO 
	res_qst_basement_availableproperties
	(
		RES_QST_Basement_AvailablePropertyID,
		RES_QST_Questionnaire_Version_RefID,
		RES_STR_Basement_Property_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@RES_QST_Basement_AvailablePropertyID,
		@RES_QST_Questionnaire_Version_RefID,
		@RES_STR_Basement_Property_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)