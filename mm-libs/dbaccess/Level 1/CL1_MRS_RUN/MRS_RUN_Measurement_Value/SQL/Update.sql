UPDATE 
	mrs_run_measurement_values
SET 
	Measurement_RefID=@Measurement_RefID,
	MeasurementValue=@MeasurementValue,
	MeasurementTariff_RefID=@MeasurementTariff_RefID,
	MeasuredAt_Time=@MeasuredAt_Time,
	MeasuredAt_Lattitude=@MeasuredAt_Lattitude,
	MeasuredAt_Longitude=@MeasuredAt_Longitude,
	Measurement_AcquisitionType_RefID=@Measurement_AcquisitionType_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	MRS_RUN_Measurement_ValueID = @MRS_RUN_Measurement_ValueID