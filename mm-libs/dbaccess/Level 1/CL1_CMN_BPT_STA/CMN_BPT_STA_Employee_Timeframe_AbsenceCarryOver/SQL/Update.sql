UPDATE 
	cmn_bpt_sta_employee_timeframe_absencecarryovers
SET 
	CalculationTimeframe_RefID=@CalculationTimeframe_RefID,
	Employee_RefID=@Employee_RefID,
	AbsenceReason_RefID=@AbsenceReason_RefID,
	R_CarryOverAmount_InMinutes=@R_CarryOverAmount_InMinutes,
	R_TotalAbsenceTimeUsed_InMinutes=@R_TotalAbsenceTimeUsed_InMinutes,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_BPT_STA_Employee_AbsenceCarryOverID = @CMN_BPT_STA_Employee_AbsenceCarryOverID