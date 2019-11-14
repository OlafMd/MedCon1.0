UPDATE 
	mrs_run_measurementrun_accountdownloadcodes
SET 
	MeasurementRun_RefID=@MeasurementRun_RefID,
	Account_RefID=@Account_RefID,
	ValidFrom=@ValidFrom,
	ValidThrough=@ValidThrough,
	DownloadCode=@DownloadCode,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	MRS_RUN_MeasurementRun_AccountDownloadCodeID = @MRS_RUN_MeasurementRun_AccountDownloadCodeID