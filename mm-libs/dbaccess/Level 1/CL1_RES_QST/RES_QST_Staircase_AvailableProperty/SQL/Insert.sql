INSERT INTO 
	res_qst_staircase_availableproperties
	(
		RES_QST_Staircase_AvailablePropertyID,
		RES_QST_Questionnaire_Version_RefID,
		RES_STR_Staircase_Property_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@RES_QST_Staircase_AvailablePropertyID,
		@RES_QST_Questionnaire_Version_RefID,
		@RES_STR_Staircase_Property_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)