UPDATE 
	cmn_bpt_emp_employee_dailyovertimeentries
SET 
	BoundTo_CalculationTimeframe_RefID=@BoundTo_CalculationTimeframe_RefID,
	Employee_RefID=@Employee_RefID,
	OvertimeEntryDate=@OvertimeEntryDate,
	Overtime_InMinutes=@Overtime_InMinutes,
	Overtime_InDays=@Overtime_InDays,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_BPT_EMP_Employee_DailyOvertimeEntryID = @CMN_BPT_EMP_Employee_DailyOvertimeEntryID