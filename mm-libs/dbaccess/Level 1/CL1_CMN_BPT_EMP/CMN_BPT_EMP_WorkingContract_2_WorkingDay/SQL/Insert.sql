INSERT INTO 
	cmn_bpt_emp_workingcontract_2_workingdays
	(
		AssignmentID,
		CMN_BPT_EMP_WorkingContract_RefID,
		CMN_CAL_WeeklyOfficeHours_Interval_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@AssignmentID,
		@CMN_BPT_EMP_WorkingContract_RefID,
		@CMN_CAL_WeeklyOfficeHours_Interval_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)