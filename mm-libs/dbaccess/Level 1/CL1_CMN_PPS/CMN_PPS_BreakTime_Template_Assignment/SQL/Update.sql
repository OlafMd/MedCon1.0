UPDATE 
	cmn_pps_breaktime_template_assignments
SET 
	BreakTime_Template_RefID=@BreakTime_Template_RefID,
	BreakTime_RefID=@BreakTime_RefID,
	StartTimeOffset_in_sec=@StartTimeOffset_in_sec,
	Duration_in_sec=@Duration_in_sec,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_PPS_BreakTime_Template_AssignmentID = @CMN_PPS_BreakTime_Template_AssignmentID