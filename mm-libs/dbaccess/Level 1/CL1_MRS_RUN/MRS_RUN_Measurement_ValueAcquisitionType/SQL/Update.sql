UPDATE 
	mrs_run_measurement_valueacquisitiontypes
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	DisplayName=@DisplayName,
	AcquisitionType_Name_DictID=@AcquisitionType_Name,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	MRS_RUN_Measurement_ValueAcquisitionTypeID = @MRS_RUN_Measurement_ValueAcquisitionTypeID