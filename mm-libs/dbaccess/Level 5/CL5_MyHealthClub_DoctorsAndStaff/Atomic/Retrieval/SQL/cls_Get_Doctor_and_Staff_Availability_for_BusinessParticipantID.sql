
Select
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  cmn_per_personinfo.Title,
  cmn_cal_ava_availability_types.IsDefaultAvailabilityType,
  cmn_cal_ava_availability_types.GlobalPropertyMatchingID,
  cmn_cal_ava_dates.DateName,
  cmn_cal_events.StartTime,
  cmn_cal_events.EndTime,
  cmn_cal_repetitions.IsMonthly,
  cmn_cal_repetitions.IsYearly,
  cmn_cal_repetitions.IsWeekly,
  cmn_bpt_businessparticipant_availabilities.CMN_BPT_BusinessParticipant_AvailabilityID,
  cmn_cal_repetitionpatterns_weekly.HasRepeatingOn_Mondays,
  cmn_cal_repetitionpatterns_weekly.HasRepeatingOn_Tuesdays,
  cmn_cal_repetitionpatterns_weekly.HasRepeatingOn_Wednesdays,
  cmn_cal_repetitionpatterns_weekly.HasRepeatingOn_Thursdays,
  cmn_cal_repetitionpatterns_weekly.HasRepeatingOn_Fridays,
  cmn_cal_repetitionpatterns_weekly.HasRepeatingOn_Saturdays,
  cmn_cal_repetitionpatterns_weekly.HasRepeatingOn_Sundays,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  cmn_cal_ava_availabilities.Office_RefID,
  cmn_cal_ava_availabilities.IsAvailabilityExclusionItem,
  cmn_cal_repetitions.IsDaily,
  cmn_cal_events.IsRepetitive,
  cmn_cal_events.IsWholeDayEvent,
  cmn_cal_ava_dates.DateComment As Reason,
  cmn_bpt_businessparticipant_excludedavailabilitytypes.CMN_BPT_BusinessParticipant_ExcludedAvailabilityTypeID,
  cmn_bpt_businessparticipant_availabilities.Creation_Timestamp
From
  cmn_bpt_businessparticipants Inner Join
  cmn_per_personinfo On cmn_per_personinfo.CMN_PER_PersonInfoID =
    cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID And
    cmn_per_personinfo.IsDeleted = 0 And cmn_per_personinfo.Tenant_RefID =
    @TenantID Left Join
  cmn_bpt_businessparticipant_availabilities
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    cmn_bpt_businessparticipant_availabilities.BusinessParticipant_RefID And
    cmn_bpt_businessparticipant_availabilities.Tenant_RefID = @TenantID And
    cmn_bpt_businessparticipant_availabilities.IsDeleted = 0 Left Join
  cmn_cal_ava_availabilities
    On cmn_bpt_businessparticipant_availabilities.CMN_CAL_AVA_Availability_RefID
    = cmn_cal_ava_availabilities.CMN_CAL_AVA_AvailabilityID And
    cmn_cal_ava_availabilities.Tenant_RefID = @TenantID And
    cmn_cal_ava_availabilities.IsDeleted = 0 Left Join
  cmn_cal_ava_availability_types
    On cmn_cal_ava_availabilities.AvailabilityType_RefID =
    cmn_cal_ava_availability_types.CMN_CAL_AVA_Availability_TypeID And
    cmn_cal_ava_availability_types.Tenant_RefID = @TenantID And
    cmn_cal_ava_availability_types.IsDeleted = 0 Left Join
  cmn_cal_ava_dates On cmn_cal_ava_availabilities.CMN_CAL_AVA_AvailabilityID =
    cmn_cal_ava_dates.Availability_RefID And cmn_cal_ava_dates.Tenant_RefID =
    @TenantID And cmn_cal_ava_dates.IsDeleted = 0 Left Join
  cmn_cal_events On cmn_cal_ava_dates.CMN_CAL_Event_RefID =
    cmn_cal_events.CMN_CAL_EventID
    And cmn_cal_events.IsDeleted = 0 And cmn_cal_events.Tenant_RefID = @TenantID
  Left Join
  cmn_cal_repetitions On cmn_cal_events.Repetition_RefID =
    cmn_cal_repetitions.CMN_CAL_RepetitionID And cmn_cal_repetitions.IsDeleted =
    0 And cmn_cal_repetitions.Tenant_RefID = @TenantID Left Join
  cmn_cal_repetitionpatterns_weekly On cmn_cal_repetitions.CMN_CAL_RepetitionID
    = cmn_cal_repetitionpatterns_weekly.Repetition_RefID And
    cmn_cal_repetitionpatterns_weekly.IsDeleted = 0 And
    cmn_cal_repetitionpatterns_weekly.Tenant_RefID = @TenantID Left Join
  cmn_bpt_businessparticipant_excludedavailabilitytypes
    On
    cmn_bpt_businessparticipant_excludedavailabilitytypes.CMN_BPT_BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And cmn_bpt_businessparticipant_excludedavailabilitytypes.IsDeleted = 0 And cmn_bpt_businessparticipant_excludedavailabilitytypes.Tenant_RefID = @TenantID
Where
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID = @StaffID And
  cmn_bpt_businessparticipants.IsCompany = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
  cmn_bpt_businessparticipants.IsNaturalPerson = 1

  