INSERT INTO 
	cmn_bpt_emp_sta_overtimestatistics
	(
		CMN_BPT_EMP_STA_OvertimeStatisticsID,
		CMN_CAL_CalculationTimeframe_RefID,
		Employee_RefID,
		OvertimeIn_EmployeeDays,
		OvertimeIn_EmployeeHours,
		IsOvertimeInEmployeeDays,
		IsOvertimeInEmployeeHours,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@CMN_BPT_EMP_STA_OvertimeStatisticsID,
		@CMN_CAL_CalculationTimeframe_RefID,
		@Employee_RefID,
		@OvertimeIn_EmployeeDays,
		@OvertimeIn_EmployeeHours,
		@IsOvertimeInEmployeeDays,
		@IsOvertimeInEmployeeHours,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)