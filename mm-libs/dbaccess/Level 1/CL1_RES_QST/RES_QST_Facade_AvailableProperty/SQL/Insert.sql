INSERT INTO 
	res_qst_facade_availableproperties
	(
		RES_QST_Facade_AvailablePropertyID,
		RES_QST_Questionnaire_Version_RefID,
		RES_STR_Facade_Property_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@RES_QST_Facade_AvailablePropertyID,
		@RES_QST_Questionnaire_Version_RefID,
		@RES_STR_Facade_Property_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)