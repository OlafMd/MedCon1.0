INSERT INTO 
	mrs_run_measurement_expectedvalues
	(
		MRS_RUN_Measurement_ExpectedValueID,
		MRS_RUN_Measurement_RefID,
		ExpectedValueMax,
		ExpectedValueMin,
		MeasurementTariff_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@MRS_RUN_Measurement_ExpectedValueID,
		@MRS_RUN_Measurement_RefID,
		@ExpectedValueMax,
		@ExpectedValueMin,
		@MeasurementTariff_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)