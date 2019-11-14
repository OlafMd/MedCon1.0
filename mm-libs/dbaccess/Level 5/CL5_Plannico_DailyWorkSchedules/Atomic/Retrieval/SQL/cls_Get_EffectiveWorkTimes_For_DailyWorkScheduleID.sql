
	Select
  cmn_str_pps_effectiveworktimes.CMN_STR_PPS_EffectiveWorkTimeID,
  cmn_str_pps_effectiveworktimes.CMN_BPT_EMP_Employe_RefID,
  cmn_str_pps_effectiveworktimes.BoundTo_DailyWorkShedule_Detail_RefID,
  cmn_str_pps_effectiveworktimes.Activity_RefID,
  cmn_str_pps_effectiveworktimes.Workplace_RefID,
  cmn_str_pps_effectiveworktimes.CMN_BPT_EMP_Employee_LeaveRequest_RefID,
  cmn_str_pps_effectiveworktimes.WorkTime_StartTime,
  cmn_str_pps_effectiveworktimes.WorkTime_Duration_in_sec,
  cmn_str_pps_effectiveworktimes.SourceOfEntry
From
  cmn_str_pps_effectiveworktimes Inner Join
  cmn_str_pps_dailyworkschedule_details
    On cmn_str_pps_effectiveworktimes.BoundTo_DailyWorkShedule_Detail_RefID =
    cmn_str_pps_dailyworkschedule_details.CMN_STR_PPS_DailyWorkSchedule_DetailID
  Inner Join
  cmn_str_pps_dailyworkschedules
    On cmn_str_pps_dailyworkschedule_details.DailyWorkSchedule_RefID =
    cmn_str_pps_dailyworkschedules.CMN_STR_PPS_DailyWorkScheduleID
Where
  cmn_str_pps_effectiveworktimes.Tenant_RefID = @TenantID And
  cmn_str_pps_effectiveworktimes.IsDeleted = 0 And
  cmn_str_pps_dailyworkschedules.CMN_STR_PPS_DailyWorkScheduleID =
  @DailyWorkScheduleID
  