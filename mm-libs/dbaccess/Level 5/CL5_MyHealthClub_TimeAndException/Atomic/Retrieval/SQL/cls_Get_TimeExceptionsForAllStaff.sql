
	Select
    cmn_cal_events.StartTime,
    cmn_cal_events.EndTime,
    cmn_cal_repetitions.IsMonthly,
    cmn_cal_repetitions.IsYearly,
    cmn_cal_repetitions.IsWeekly,
    cmn_cal_repetitions.IsDaily,
    cmn_cal_events.IsRepetitive,
    cmn_cal_events.IsWholeDayEvent,
    cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID,
    cmn_cal_events.CMN_CAL_EventID
  From
    cmn_bpt_businessparticipant_availabilities Inner Join
    cmn_cal_ava_availabilities
      On cmn_bpt_businessparticipant_availabilities.CMN_CAL_AVA_Availability_RefID
      = cmn_cal_ava_availabilities.CMN_CAL_AVA_AvailabilityID And
      cmn_cal_ava_availabilities.Tenant_RefID = @TenantID And
      cmn_cal_ava_availabilities.IsDeleted = 0 Inner Join
    cmn_cal_ava_availability_types
      On cmn_cal_ava_availabilities.AvailabilityType_RefID =
      cmn_cal_ava_availability_types.CMN_CAL_AVA_Availability_TypeID And
      cmn_cal_ava_availability_types.Tenant_RefID = @TenantID And
      cmn_cal_ava_availability_types.IsDeleted = 0 Inner Join
    cmn_cal_ava_dates On cmn_cal_ava_availabilities.CMN_CAL_AVA_AvailabilityID =
      cmn_cal_ava_dates.Availability_RefID And cmn_cal_ava_dates.Tenant_RefID =
      @TenantID And cmn_cal_ava_dates.IsDeleted = 0 Inner Join
    cmn_cal_events On cmn_cal_ava_dates.CMN_CAL_Event_RefID =
      cmn_cal_events.CMN_CAL_EventID And cmn_cal_events.IsDeleted = 0 And
      cmn_cal_events.Tenant_RefID = @TenantID Left Join
    cmn_cal_repetitions On cmn_cal_events.Repetition_RefID =
      cmn_cal_repetitions.CMN_CAL_RepetitionID And cmn_cal_repetitions.IsDeleted =
      0 And cmn_cal_repetitions.Tenant_RefID = @TenantID Inner Join
    cmn_bpt_emp_employees
      On cmn_bpt_businessparticipant_availabilities.BusinessParticipant_RefID =
      cmn_bpt_emp_employees.BusinessParticipant_RefID
  Where
    cmn_cal_ava_availability_types.GlobalPropertyMatchingID =
    'availability-types.exception' And
    cmn_cal_ava_availabilities.IsAvailabilityExclusionItem = 1 And
    cmn_bpt_businessparticipant_availabilities.IsDeleted = 0
  