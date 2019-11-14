UPDATE 
	mrs_run_measurement_tariffs
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	MeasurementTariffName_DictID=@MeasurementTariffName,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	MRS_RUN_Measurement_TariffID = @MRS_RUN_Measurement_TariffID