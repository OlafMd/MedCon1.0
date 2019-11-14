UPDATE 
	mrs_run_measurement_issue_types
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	IssueTypeName_DictID=@IssueTypeName,
	IssueTypeDescription_DictID=@IssueTypeDescription,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	MRS_RUN_Measurement_Issue_TypeID = @MRS_RUN_Measurement_Issue_TypeID