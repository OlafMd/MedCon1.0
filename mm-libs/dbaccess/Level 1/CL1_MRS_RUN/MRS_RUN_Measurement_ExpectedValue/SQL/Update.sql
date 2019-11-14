UPDATE 
	mrs_run_measurement_expectedvalues
SET 
	MRS_RUN_Measurement_RefID=@MRS_RUN_Measurement_RefID,
	ExpectedValueMax=@ExpectedValueMax,
	ExpectedValueMin=@ExpectedValueMin,
	MeasurementTariff_RefID=@MeasurementTariff_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	MRS_RUN_Measurement_ExpectedValueID = @MRS_RUN_Measurement_ExpectedValueID