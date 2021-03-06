 
Select
  cmn_bpt_emp_employee_absencereason_timeframestatistics.R_TotalAllowedAbsenceTime_InDays,
  cmn_bpt_emp_employee_absencereason_timeframestatistics.R_TotalAllowedAbsenceTime_InHours,
  cmn_bpt_emp_employee_absencereason_timeframestatistics.R_RequestReservedAbsence_InDays,
  cmn_bpt_emp_employee_absencereason_timeframestatistics.R_RequestReservedAbsence_InHours,
  cmn_bpt_emp_employee_absencereason_timeframestatistics.R_AbsenceTimeUsed_InDays,
  cmn_bpt_emp_employee_absencereason_timeframestatistics.R_AbsenceTimeUsed_InHours,
  cmn_bpt_emp_employee_absencereason_timeframestatistics.R_AbsenceCarryOver_InHours,
  cmn_bpt_emp_employee_absencereason_timeframestatistics.R_AbsenceCarryOver_InDays,
  cmn_bpt_emp_employee_absencereason_timeframestatistics.CMN_BPT_EMP_Employee_AbsenceReason_TimeframeStatisticsID,
  cmn_bpt_emp_employee_absencereason_timeframestatistics.AbsenceReason_RefID,
  cmn_bpt_emp_employee_absencereason_timeframestatistics.Employee_RefID,
  cmn_bpt_emp_employee_absencereason_timeframestatistics.CalculationTimeframe_RefID
From
  cmn_bpt_emp_employee_absencereason_timeframestatistics
Where
  cmn_bpt_emp_employee_absencereason_timeframestatistics.AbsenceReason_RefID =
  @absenceReasonID And
  cmn_bpt_emp_employee_absencereason_timeframestatistics.Employee_RefID =
  @employeeID And
  cmn_bpt_emp_employee_absencereason_timeframestatistics.CalculationTimeframe_RefID = @timeFrameID And
  cmn_bpt_emp_employee_absencereason_timeframestatistics.IsDeleted = 0 And
  cmn_bpt_emp_employee_absencereason_timeframestatistics.Tenant_RefID =
  @TenantID
  