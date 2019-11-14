INSERT INTO 
	cmn_bpt_emp_employee_dailyovertimeentries
	(
		CMN_BPT_EMP_Employee_DailyOvertimeEntryID,
		BoundTo_CalculationTimeframe_RefID,
		Employee_RefID,
		OvertimeEntryDate,
		Overtime_InMinutes,
		Overtime_InDays,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@CMN_BPT_EMP_Employee_DailyOvertimeEntryID,
		@BoundTo_CalculationTimeframe_RefID,
		@Employee_RefID,
		@OvertimeEntryDate,
		@Overtime_InMinutes,
		@Overtime_InDays,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)