UPDATE 
	mrs_run_measurements
SET 
	MeasurementRun_RefID=@MeasurementRun_RefID,
	MeasuringPoint_RefID=@MeasuringPoint_RefID,
	IsMeasured=@IsMeasured,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	MRS_RUN_MeasurementID = @MRS_RUN_MeasurementID