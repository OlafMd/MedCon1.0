UPDATE 
	mrs_run_measurementrun_statushistory
SET 
	MeasurementRun_RefID=@MeasurementRun_RefID,
	MeasurementRun_Status_RefID=@MeasurementRun_Status_RefID,
	TriggeredBy_BusinessParticipant_RefID=@TriggeredBy_BusinessParticipant_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	MRS_RUN_MeasurementRun_StatusHistoryID = @MRS_RUN_MeasurementRun_StatusHistoryID