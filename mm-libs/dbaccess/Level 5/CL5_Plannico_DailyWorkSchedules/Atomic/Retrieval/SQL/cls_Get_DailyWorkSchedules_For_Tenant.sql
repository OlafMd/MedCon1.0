
Select
  cmn_str_pps_dailyworkschedules.CMN_STR_PPS_DailyWorkScheduleID,
  cmn_str_pps_dailyworkschedules.Employee_RefID,
  cmn_str_pps_dailyworkschedules.WorkSheduleDate,
  cmn_str_pps_dailyworkschedules.InstantiatedWithShiftTemplate_RefID,
  cmn_str_pps_dailyworkschedules.SheduleBreakTemplate_RefID,
  cmn_str_pps_dailyworkschedules.IsBreakTimeManualySpecified,
  cmn_str_pps_dailyworkschedules.WorkingSheduleComment,
  cmn_str_pps_dailyworkschedules.ContractWorkerText,
  cmn_str_pps_dailyworkschedules.R_WorkDay_Start_in_sec,
  cmn_str_pps_dailyworkschedules.R_WorkDay_Duration_in_sec,
  cmn_str_pps_dailyworkschedules.BreakDurationTime_in_sec,
  cmn_str_pps_dailyworkschedules.R_ContractSpecified_WorkingTime_in_sec,
  cmn_str_pps_dailyworkschedules.IsWorkShedule_Confirmed,
  cmn_str_pps_dailyworkschedules.WorkShedule_ConfirmedBy_Account_RefID,
  cmn_str_pps_dailyworkschedules.R_WorkDay_End_in_sec
From
  cmn_str_pps_dailyworkschedules
Where
  cmn_str_pps_dailyworkschedules.IsDeleted = 0 And
  cmn_str_pps_dailyworkschedules.Tenant_RefID = @TenantID
  