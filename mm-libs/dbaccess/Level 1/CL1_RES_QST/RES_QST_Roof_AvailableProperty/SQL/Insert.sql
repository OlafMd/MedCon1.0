INSERT INTO 
	res_qst_roof_availableproperties
	(
		RES_QST_Roof_AvailablePropertyID,
		RES_QST_Questionnaire_Version_RefID,
		RES_STR_Roof_Property_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@RES_QST_Roof_AvailablePropertyID,
		@RES_QST_Questionnaire_Version_RefID,
		@RES_STR_Roof_Property_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)