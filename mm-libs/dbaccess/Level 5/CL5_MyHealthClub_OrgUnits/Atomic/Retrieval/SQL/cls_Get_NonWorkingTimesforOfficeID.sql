
	Select
	  cmn_str_office_worktimetemplateexceptions.Description,
	  cmn_str_office_worktimetemplateexceptions.CMN_STR_Office_WorktimeTemplateExceptionID As TimeID,
	  cmn_cal_events.IsRepetitive,
	  cmn_cal_events.IsWholeDayEvent,
	  cmn_cal_events.StartTime,
	  cmn_cal_events.EndTime,
	  cmn_cal_repetitions.IsDaily,
	  cmn_cal_repetitions.IsWeekly,
	  cmn_cal_repetitions.IsMonthly,
	  cmn_cal_repetitions.IsYearly
	From
	  cmn_str_office_worktimetemplateexceptions Inner Join
	  cmn_cal_events
	    On cmn_str_office_worktimetemplateexceptions.CMN_CAL_Event_RefID =
	    cmn_cal_events.CMN_CAL_EventID And cmn_cal_events.Tenant_RefID = @TenantID
	    And cmn_cal_events.IsDeleted = 0 Left Join
	  cmn_cal_repetitions On cmn_cal_events.Repetition_RefID =
	    cmn_cal_repetitions.CMN_CAL_RepetitionID And cmn_cal_repetitions.IsDeleted =
	    0 And cmn_cal_repetitions.Tenant_RefID = @TenantID
	Where
	  cmn_str_office_worktimetemplateexceptions.Tenant_RefID = @TenantID And
	  cmn_str_office_worktimetemplateexceptions.IsDeleted = 0 And
	  cmn_str_office_worktimetemplateexceptions.Office_RefID = @OfficeID
  