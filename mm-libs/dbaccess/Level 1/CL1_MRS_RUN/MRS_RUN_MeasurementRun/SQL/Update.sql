UPDATE 
	mrs_run_measurementrun
SET 
	DateFrom=@DateFrom,
	DateThrough=@DateThrough,
	IsCorrectionRun=@IsCorrectionRun,
	CorrectionOf_MeasurementRun_RefID=@CorrectionOf_MeasurementRun_RefID,
	CurrentStatus_RefID=@CurrentStatus_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	MRS_RUN_MeasurementRunID = @MRS_RUN_MeasurementRunID