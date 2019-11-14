UPDATE 
	cmn_bpt_emp_workingcontract_2_workingdays
SET 
	CMN_BPT_EMP_WorkingContract_RefID=@CMN_BPT_EMP_WorkingContract_RefID,
	CMN_CAL_WeeklyOfficeHours_Interval_RefID=@CMN_CAL_WeeklyOfficeHours_Interval_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID