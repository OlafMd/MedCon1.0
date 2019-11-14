UPDATE 
	cmn_bpt_emp_sta_overtimestatistics
SET 
	CMN_CAL_CalculationTimeframe_RefID=@CMN_CAL_CalculationTimeframe_RefID,
	Employee_RefID=@Employee_RefID,
	OvertimeIn_EmployeeDays=@OvertimeIn_EmployeeDays,
	OvertimeIn_EmployeeHours=@OvertimeIn_EmployeeHours,
	IsOvertimeInEmployeeDays=@IsOvertimeInEmployeeDays,
	IsOvertimeInEmployeeHours=@IsOvertimeInEmployeeHours,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_BPT_EMP_STA_OvertimeStatisticsID = @CMN_BPT_EMP_STA_OvertimeStatisticsID