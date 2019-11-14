
	Select
	  cmn_per_personinfo.FirstName,
	  cmn_per_personinfo.LastName,
	  cmn_per_personinfo.Title,
	  cmn_cal_ava_dates.DateComment As Description,
	  cmn_cal_events.IsRepetitive,
	  cmn_cal_events.IsWholeDayEvent,
	  cmn_cal_events.StartTime,
	  cmn_cal_events.EndTime,
	  cmn_cal_repetitions.IsDaily,
	  cmn_cal_repetitions.IsWeekly,
	  cmn_cal_repetitions.IsMonthly,
	  cmn_cal_repetitions.IsYearly
	From
	  cmn_bpt_businessparticipants Inner Join
	  cmn_per_personinfo
	    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
	    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.IsDeleted = 0
	    And
	    cmn_per_personinfo.Tenant_RefID = @TenantID Inner Join
	  cmn_bpt_businessparticipant_availabilities
	    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
	    cmn_bpt_businessparticipant_availabilities.BusinessParticipant_RefID And
	    cmn_bpt_businessparticipant_availabilities.IsDeleted = 0 And
	    cmn_bpt_businessparticipant_availabilities.Tenant_RefID =
	    @TenantID Inner Join
	  cmn_cal_ava_availabilities
	    On cmn_bpt_businessparticipant_availabilities.CMN_CAL_AVA_Availability_RefID
	    = cmn_cal_ava_availabilities.CMN_CAL_AVA_AvailabilityID And
	    cmn_cal_ava_availabilities.IsDeleted = 0 And
	    cmn_cal_ava_availabilities.Tenant_RefID =
	    @TenantID Inner Join
	  cmn_cal_ava_dates On cmn_cal_ava_availabilities.CMN_CAL_AVA_AvailabilityID =
	    cmn_cal_ava_dates.Availability_RefID And cmn_cal_ava_dates.Tenant_RefID =
	    @TenantID And
	    cmn_cal_ava_dates.IsDeleted = 0 Inner Join
	  cmn_cal_events On cmn_cal_ava_dates.CMN_CAL_Event_RefID =
	    cmn_cal_events.CMN_CAL_EventID And cmn_cal_events.IsDeleted = 0 And
	    cmn_cal_events.Tenant_RefID = @TenantID Left Join
	  cmn_cal_repetitions On cmn_cal_repetitions.CMN_CAL_RepetitionID =
	    cmn_cal_events.Repetition_RefID And cmn_cal_repetitions.IsDeleted = 0 And
	    cmn_cal_repetitions.Tenant_RefID = @TenantID
	Where
	  cmn_cal_ava_availabilities.IsAvailabilityExclusionItem = 1 And
	  cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
	  cmn_bpt_businessparticipants.Tenant_RefID =
	  @TenantID And
	  cmn_bpt_businessparticipants.IsDeleted = 0 And
	  cmn_bpt_businessparticipants.IsCompany = 0
  