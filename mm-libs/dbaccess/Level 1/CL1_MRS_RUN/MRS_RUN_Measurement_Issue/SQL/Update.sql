UPDATE 
	mrs_run_measurement_issues
SET 
	Measurement_RefID=@Measurement_RefID,
	MeasurementIssueType_RefID=@MeasurementIssueType_RefID,
	IssueComment=@IssueComment,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	MRS_RUN_Measurement_IssueID = @MRS_RUN_Measurement_IssueID