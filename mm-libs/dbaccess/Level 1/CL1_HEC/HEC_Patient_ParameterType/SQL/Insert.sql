INSERT INTO 
	hec_patient_parametertypes
	(
		HEC_Patient_ParameterTypeID,
		GlobalPropertyMatchingID,
		Name_DictID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@HEC_Patient_ParameterTypeID,
		@GlobalPropertyMatchingID,
		@Name,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)