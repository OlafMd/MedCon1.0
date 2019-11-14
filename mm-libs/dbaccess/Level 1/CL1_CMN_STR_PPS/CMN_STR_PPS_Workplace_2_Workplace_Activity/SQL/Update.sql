UPDATE 
	cmn_str_pps_workplace_2_workplace_activities
SET 
	Workplace_RefID=@Workplace_RefID,
	Workplace_Activity_RefID=@Workplace_Activity_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID