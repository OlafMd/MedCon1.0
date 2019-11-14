INSERT INTO 
	mrs_run_measurement_valueacquisitiontypes
	(
		MRS_RUN_Measurement_ValueAcquisitionTypeID,
		GlobalPropertyMatchingID,
		DisplayName,
		AcquisitionType_Name_DictID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@MRS_RUN_Measurement_ValueAcquisitionTypeID,
		@GlobalPropertyMatchingID,
		@DisplayName,
		@AcquisitionType_Name,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)