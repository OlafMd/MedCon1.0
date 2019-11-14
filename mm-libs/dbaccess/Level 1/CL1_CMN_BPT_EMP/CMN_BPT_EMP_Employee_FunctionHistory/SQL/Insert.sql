INSERT INTO 
	cmn_bpt_emp_employee_functionhistory
	(
		CMN_BPT_EMP_Employee_FunctionHistoryID,
		CMN_BPT_EMP_Employee_RefID,
		CMN_BPT_EMP_WorkingContract_RefID,
		ValidThrough,
		ValidFrom,
		FunctionName,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@CMN_BPT_EMP_Employee_FunctionHistoryID,
		@CMN_BPT_EMP_Employee_RefID,
		@CMN_BPT_EMP_WorkingContract_RefID,
		@ValidThrough,
		@ValidFrom,
		@FunctionName,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)