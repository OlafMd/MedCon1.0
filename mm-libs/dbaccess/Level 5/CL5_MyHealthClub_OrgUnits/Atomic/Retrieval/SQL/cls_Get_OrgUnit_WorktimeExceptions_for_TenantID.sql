
	Select
	  cmn_cal_events.IsRepetitive,
	  cmn_cal_events.IsWholeDayEvent,
	  cmn_cal_events.StartTime,
	  cmn_cal_events.EndTime,
	  cmn_cal_repetitions.IsDaily,
	  cmn_cal_repetitions.IsWeekly,
	  cmn_cal_repetitions.IsMonthly,
	  cmn_cal_repetitions.IsYearly,
	  cmn_str_offices.Office_Name_DictID,
	  cmn_str_office_worktimetemplateexceptions.Description
	From
	  cmn_str_office_worktimetemplateexceptions Inner Join
	  cmn_cal_events
	    On cmn_str_office_worktimetemplateexceptions.CMN_CAL_Event_RefID =
	    cmn_cal_events.CMN_CAL_EventID And cmn_cal_events.Tenant_RefID = @TenantID
	    And cmn_cal_events.IsDeleted = 0 Left Join
	  cmn_cal_repetitions On cmn_cal_events.Repetition_RefID =
	    cmn_cal_repetitions.CMN_CAL_RepetitionID And cmn_cal_repetitions.IsDeleted =
	    0 And cmn_cal_repetitions.Tenant_RefID = @TenantID Inner Join
	  cmn_str_offices On cmn_str_offices.CMN_STR_OfficeID =
	    cmn_str_office_worktimetemplateexceptions.Office_RefID And
	    cmn_str_office_worktimetemplateexceptions.Tenant_RefID = @TenantID
	    And cmn_str_office_worktimetemplateexceptions.IsDeleted = 0
	Where
	  cmn_str_offices.IsDeleted = 0 And
	  cmn_str_offices.Tenant_RefID = @TenantID
  