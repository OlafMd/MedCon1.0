INSERT INTO 
	cmn_bpt_emp_workingcontract_2_contractemploymenttypes
	(
		AssignmentID,
		CMN_BPT_EMP_Employee_WorkingContract_RefID,
		CMN_BPT_EMP_WorkingContract_EmploymentTypeID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@AssignmentID,
		@CMN_BPT_EMP_Employee_WorkingContract_RefID,
		@CMN_BPT_EMP_WorkingContract_EmploymentTypeID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)