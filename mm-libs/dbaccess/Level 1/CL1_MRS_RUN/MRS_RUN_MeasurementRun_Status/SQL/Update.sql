UPDATE 
	mrs_run_measurementrun_statuses
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	StatusDisplayName=@StatusDisplayName,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	MRS_RUN_MeasurementRun_StatusID = @MRS_RUN_MeasurementRun_StatusID