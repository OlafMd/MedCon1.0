

	Select
  RepetiotionPaterns.CMN_CAL_RepetitionID,
  RepetiotionPaterns.IsDaily,
  RepetiotionPaterns.IsMonthly,
  RepetiotionPaterns.IsWeekly,
  RepetiotionPaterns.IsYearly,
  RepetiotionPaterns.R_CronExpression,
  RepetiotionPaterns.relativeCMN_CAL_RepetitionPattern_RelativeID,
  RepetiotionPaterns.relativeOrdinal,
  RepetiotionPaterns.relativeIsWeekDay,
  RepetiotionPaterns.relativeIsWeekendDay,
  RepetiotionPaterns.relativeIsMonday,
  RepetiotionPaterns.relativeIsTuesday,
  RepetiotionPaterns.relativeIsThursday,
  RepetiotionPaterns.relativeIsFriday,
  RepetiotionPaterns.relativeIsWednesday,
  RepetiotionPaterns.relativeIsSaturday,
  RepetiotionPaterns.yearlyCMN_CAL_RepetitionPattern_YearlyID,
  RepetiotionPaterns.relativeIsSunday,
  RepetiotionPaterns.yearlyRepetition_EveryNumberOfYears,
  RepetiotionPaterns.yearlyIsFixed,
  RepetiotionPaterns.yearlyRepetition_Month,
  RepetiotionPaterns.yearlyIsRelative,
  RepetiotionPaterns.yearlyIfFixed_DayOfMonth,
  RepetiotionPaterns.monthlyIfFixed_DayOfMonth,
  RepetiotionPaterns.monthlyIsRelative,
  RepetiotionPaterns.weeklyHasRepeatingOn_Sundays,
  RepetiotionPaterns.weeklyHasRepeatingOn_Saturdays,
  RepetiotionPaterns.weeklyHasRepeatingOn_Thursdays,
  RepetiotionPaterns.weeklyHasRepeatingOn_Fridays,
  RepetiotionPaterns.weeklyHasRepeatingOn_Wednesdays,
  RepetiotionPaterns.weeklyHasRepeatingOn_Tuesdays,
  RepetiotionPaterns.weeklyHasRepeatingOn_Mondays,
  RepetiotionPaterns.weeklyRepetition_EveryNumberOfWeeks,
  RepetiotionPaterns.weeklyCMN_CAL_RepetitionPattern_WeeklyID,
  RepetiotionPaterns.dailyRepetition_EveryNumberOfDays,
  RepetiotionPaterns.dailyCMN_CAL_RepetitionPattern_DailyID,
  RepetiotionPaterns.monthlyCMN_CAL_RepetitionPattern_MonthlyID,
  RepetiotionPaterns.monthlyRepetition_EveryNumberOfMonths,
  RepetiotionPaterns.monthlyIsFixed,
  cmn_cal_repetition_ranges.CMN_CAL_Repetition_RangeID As
  repetitionRangesCMN_CAL_Repetition_RangeID,
  cmn_cal_repetition_ranges.StartDate As repetitionRangesStartDate,
  cmn_cal_repetition_ranges.HasEndType_Occurrence As
  repetitionRangesHasEndType_Occurrence,
  cmn_cal_repetition_ranges.HasEndType_DateTime As
  repetitionRangesHasEndType_DateTime,
  cmn_cal_repetition_ranges.HasEndType_NoEndDate As
  repetitionRangesHasEndType_NoEndDate,
  cmn_cal_repetition_ranges.End_AfterSpecifiedOccurrences As
  repetitionRangesEnd_AfterSpecifiedOccurrences,
  cmn_cal_repetition_ranges.End_ByDate As repetitionRangesEnd_ByDate,
  cmn_cal_events.CMN_CAL_EventID,
  cmn_cal_events.IsRepetitive,
  cmn_cal_events.StartTime,
  cmn_cal_events.EndTime,
  cmn_cal_events.R_EventDuration_sec,
  cmn_str_sce_structurecalendarevents.CMN_STR_SCE_StructureCalendarEventID,
  cmn_str_sce_structurecalendarevents.StructureEvent_Name_DictID,
  cmn_str_sce_structurecalendarevents.StructureEvent_Description_DictID,
  cmn_str_sce_structurecalendarevents.IsHavingCapacityRestriction,
  forbidenLeaveTypes.Name_DictID,
  forbidenLeaveTypes.CMN_BPT_STA_AbsenceReasonID,
  forbidenLeaveTypes.CMN_STR_SCE_ForbiddenLeaveTypeID,
  forbidenLeaveTypes.CMN_STR_SCE_StructureCalendarEvent_RefID,
  CapacityRestriction.CMN_STR_SCE_CapacityRestriction_TypeID,
  CapacityRestriction.CapacityRestrictionType_Name_DictID,
  CapacityRestriction.CMN_STR_SCE_CapacityRestrictionID,
  CapacityRestriction.IsValueCalculated_InPercentage,
  CapacityRestriction.IsValueCalculated_InHeadCount,
  CapacityRestriction.IsValueCalculated_InWorkingHours,
  CapacityRestriction.ValueCalculated,
  RepetiotionPaterns.yearlyRelativeCMN_CAL_RepetitionPattern_RelativeID,
  RepetiotionPaterns.yearlyRelativeOrdinal,
  RepetiotionPaterns.yearlyRelativeIsWeekDay,
  RepetiotionPaterns.yearlyRelativeIsWeekendDay,
  RepetiotionPaterns.yearlyRelativeIsWednesday,
  RepetiotionPaterns.yearlyRelativeIsMonday,
  RepetiotionPaterns.yearlyRelativeIsTuesday,
  RepetiotionPaterns.yearlyRelativeIsThursday,
  RepetiotionPaterns.yearlyRelativeIsSaturday,
  RepetiotionPaterns.yearlyRelativeIsFriday,
  RepetiotionPaterns.yearlyRelativeIsSunday,
  cmn_str_sce_structurecalendarevents.IsShowingNotification,
  cmn_str_sce_structurecalendarevents.IsWorkingDayEvent,
  cmn_str_sce_structurecalendarevents.IsWorkingHalfDayEvent,
  cmn_str_sce_structurecalendarevents.IsNonWorkingDay,
  cmn_cal_events.IsWholeDayEvent,
  cmn_str_sce_structurecalendarevent_types.CMN_STR_SCE_StructureCalendarEvent_TypeID As EventType_CMN_STR_SCE_StructureCalendarEvent_TypeID,
  cmn_str_sce_structurecalendarevent_types.EventIcon_RefID As
  EventType_EventIcon_RefID,
  cmn_str_sce_structurecalendarevent_types.CalendaEventName_DictID As
  EventType_CalendaEventName_DictID,
  cmn_str_sce_structurecalendarevent_types.PriorityOrdinal As
  EventType_PriorityOrdinal,
  cmn_str_sce_structurecalendarevent_types.ColorCode_Foreground As
  EventType_ColorCode_Foreground,
  cmn_str_sce_structurecalendarevent_types.ColorCode_Background As
  EventType_ColorCode_Background,
  cmn_str_sce_structurecalendarevent_types.ColorCode_Alpha As
  EventType_ColorCode_Alpha,
  cmn_str_sce_structurecalendarevent_types.IsShowingNotification As
  EventType_IsShowingNotification,
  cmn_str_sce_structurecalendarevent_types.IsWorkingDay As
  EventType_IsWorkingDay,
  cmn_str_sce_structurecalendarevent_types.IsHalfWorkingDay As
  EventType_IsHalfWorkingDay,
  cmn_str_sce_structurecalendarevent_types.IsNonWorkingDay As
  EventType_IsNonWorkingDay,
  cmn_cal_events.CalendarInstance_RefID,
  cmn_str_sce_structurecalendarevent_types.InternalEventTypeID,
  cmn_str_sce_structurecalendarevents.IsEvent_ImportedFromTemplate
From
  (Select
    cmn_cal_repetitions.CMN_CAL_RepetitionID,
    cmn_cal_repetitions.IsDaily,
    cmn_cal_repetitions.IsMonthly,
    cmn_cal_repetitions.IsWeekly,
    cmn_cal_repetitions.IsYearly,
    cmn_cal_repetitions.R_CronExpression,
    cmn_cal_repetitionpatterns_relative.CMN_CAL_RepetitionPattern_RelativeID As
    relativeCMN_CAL_RepetitionPattern_RelativeID,
    cmn_cal_repetitionpatterns_relative.Ordinal As relativeOrdinal,
    cmn_cal_repetitionpatterns_relative.IsWeekDay As relativeIsWeekDay,
    cmn_cal_repetitionpatterns_relative.IsWeekendDay As relativeIsWeekendDay,
    cmn_cal_repetitionpatterns_relative.IsMonday As relativeIsMonday,
    cmn_cal_repetitionpatterns_relative.IsTuesday As relativeIsTuesday,
    cmn_cal_repetitionpatterns_relative.IsWednesday As relativeIsWednesday,
    cmn_cal_repetitionpatterns_relative.IsThursday As relativeIsThursday,
    cmn_cal_repetitionpatterns_relative.IsFriday As relativeIsFriday,
    cmn_cal_repetitionpatterns_relative.IsSaturday As relativeIsSaturday,
    cmn_cal_repetitionpatterns_relative.IsSunday As relativeIsSunday,
    cmn_cal_repetitionpatterns_yearly.CMN_CAL_RepetitionPattern_YearlyID As
    yearlyCMN_CAL_RepetitionPattern_YearlyID,
    cmn_cal_repetitionpatterns_yearly.Repetition_EveryNumberOfYears As
    yearlyRepetition_EveryNumberOfYears,
    cmn_cal_repetitionpatterns_yearly.Repetition_Month As
    yearlyRepetition_Month,
    cmn_cal_repetitionpatterns_yearly.IsFixed As yearlyIsFixed,
    cmn_cal_repetitionpatterns_yearly.IsRelative As yearlyIsRelative,
    cmn_cal_repetitionpatterns_yearly.IfRelative_RepetitionPattern_RefID As
    yearlyIfRelative_RepetitionPattern_RefID,
    cmn_cal_repetitionpatterns_yearly.IfFixed_DayOfMonth As
    yearlyIfFixed_DayOfMonth,
    cmn_cal_repetitionpatterns_monthly.IfFixed_DayOfMonth As
    monthlyIfFixed_DayOfMonth,
    cmn_cal_repetitionpatterns_monthly.IfRelative_RepetitionPattern_RefID As
    monthlyIfRelative_RepetitionPattern_RefID,
    cmn_cal_repetitionpatterns_monthly.IsRelative As monthlyIsRelative,
    cmn_cal_repetitionpatterns_monthly.IsFixed As monthlyIsFixed,
    cmn_cal_repetitionpatterns_monthly.Repetition_EveryNumberOfMonths As
    monthlyRepetition_EveryNumberOfMonths,
    cmn_cal_repetitionpatterns_monthly.CMN_CAL_RepetitionPattern_MonthlyID As
    monthlyCMN_CAL_RepetitionPattern_MonthlyID,
    cmn_cal_repetitionpatterns_daily.CMN_CAL_RepetitionPattern_DailyID
    As dailyCMN_CAL_RepetitionPattern_DailyID,
    cmn_cal_repetitionpatterns_daily.Repetition_EveryNumberOfDays As
    dailyRepetition_EveryNumberOfDays,
    cmn_cal_repetitionpatterns_weekly.CMN_CAL_RepetitionPattern_WeeklyID As
    weeklyCMN_CAL_RepetitionPattern_WeeklyID,
    cmn_cal_repetitionpatterns_weekly.Repetition_EveryNumberOfWeeks As
    weeklyRepetition_EveryNumberOfWeeks,
    cmn_cal_repetitionpatterns_weekly.HasRepeatingOn_Mondays As
    weeklyHasRepeatingOn_Mondays,
    cmn_cal_repetitionpatterns_weekly.HasRepeatingOn_Tuesdays As
    weeklyHasRepeatingOn_Tuesdays,
    cmn_cal_repetitionpatterns_weekly.HasRepeatingOn_Wednesdays As
    weeklyHasRepeatingOn_Wednesdays,
    cmn_cal_repetitionpatterns_weekly.HasRepeatingOn_Thursdays As
    weeklyHasRepeatingOn_Thursdays,
    cmn_cal_repetitionpatterns_weekly.HasRepeatingOn_Fridays As
    weeklyHasRepeatingOn_Fridays,
    cmn_cal_repetitionpatterns_weekly.HasRepeatingOn_Saturdays As
    weeklyHasRepeatingOn_Saturdays,
    cmn_cal_repetitionpatterns_weekly.HasRepeatingOn_Sundays As
    weeklyHasRepeatingOn_Sundays,
    cmn_cal_repetitionpatterns_relative1.CMN_CAL_RepetitionPattern_RelativeID As
    yearlyRelativeCMN_CAL_RepetitionPattern_RelativeID,
    cmn_cal_repetitionpatterns_relative1.Ordinal As yearlyRelativeOrdinal,
    cmn_cal_repetitionpatterns_relative1.IsWeekDay As yearlyRelativeIsWeekDay,
    cmn_cal_repetitionpatterns_relative1.IsWeekendDay As
    yearlyRelativeIsWeekendDay,
    cmn_cal_repetitionpatterns_relative1.IsMonday As yearlyRelativeIsMonday,
    cmn_cal_repetitionpatterns_relative1.IsWednesday As
    yearlyRelativeIsWednesday,
    cmn_cal_repetitionpatterns_relative1.IsTuesday As yearlyRelativeIsTuesday,
    cmn_cal_repetitionpatterns_relative1.IsThursday As yearlyRelativeIsThursday,
    cmn_cal_repetitionpatterns_relative1.IsFriday As yearlyRelativeIsFriday,
    cmn_cal_repetitionpatterns_relative1.IsSaturday As yearlyRelativeIsSaturday,
    cmn_cal_repetitionpatterns_relative1.IsSunday As yearlyRelativeIsSunday
  From
    cmn_cal_repetitions Left Join
    cmn_cal_repetitionpatterns_daily
      On cmn_cal_repetitionpatterns_daily.Repetition_RefID =
      cmn_cal_repetitions.CMN_CAL_RepetitionID Left Join
    cmn_cal_repetitionpatterns_weekly
      On cmn_cal_repetitionpatterns_weekly.Repetition_RefID =
      cmn_cal_repetitions.CMN_CAL_RepetitionID Left Join
    cmn_cal_repetitionpatterns_monthly
      On cmn_cal_repetitionpatterns_monthly.Repetition_RefID =
      cmn_cal_repetitions.CMN_CAL_RepetitionID Left Join
    cmn_cal_repetitionpatterns_yearly
      On cmn_cal_repetitionpatterns_yearly.Repetition_RefID =
      cmn_cal_repetitions.CMN_CAL_RepetitionID Left Join
    cmn_cal_repetitionpatterns_relative
      On
      cmn_cal_repetitionpatterns_relative.CMN_CAL_RepetitionPattern_RelativeID =
      cmn_cal_repetitionpatterns_monthly.IfRelative_RepetitionPattern_RefID
    Left Join
    cmn_cal_repetitionpatterns_relative cmn_cal_repetitionpatterns_relative1
      On
      cmn_cal_repetitionpatterns_relative1.CMN_CAL_RepetitionPattern_RelativeID
      = cmn_cal_repetitionpatterns_yearly.IfRelative_RepetitionPattern_RefID
  Where
    (cmn_cal_repetitionpatterns_weekly.IsDeleted = 0 Or
      cmn_cal_repetitionpatterns_weekly.IsDeleted Is Null) And
    (cmn_cal_repetitionpatterns_yearly.IsDeleted = 0 Or
      cmn_cal_repetitionpatterns_yearly.IsDeleted Is Null) And
    (cmn_cal_repetitionpatterns_relative.IsDeleted = 0 Or
      cmn_cal_repetitionpatterns_relative.IsDeleted Is Null) And
    (cmn_cal_repetitionpatterns_monthly.IsDeleted = 0 Or
      cmn_cal_repetitionpatterns_monthly.IsDeleted Is Null) And
    (cmn_cal_repetitionpatterns_daily.IsDeleted = 0 Or
      cmn_cal_repetitionpatterns_daily.IsDeleted Is Null) And
    (cmn_cal_repetitions.IsDeleted = 0 Or
      cmn_cal_repetitions.IsDeleted Is Null) And
    cmn_cal_repetitions.Tenant_RefID = @TenantID And
    (cmn_cal_repetitionpatterns_relative1.IsDeleted = 0 Or
      cmn_cal_repetitionpatterns_relative1.IsDeleted Is Null))
  RepetiotionPaterns Left Join
  cmn_cal_repetition_ranges On cmn_cal_repetition_ranges.Repetition_RefID =
    RepetiotionPaterns.CMN_CAL_RepetitionID Right Join
  cmn_cal_events On cmn_cal_events.Repetition_RefID =
    RepetiotionPaterns.CMN_CAL_RepetitionID Inner Join
  cmn_str_sce_structurecalendarevents
    On cmn_str_sce_structurecalendarevents.CMN_CAL_Event_RefID =
    cmn_cal_events.CMN_CAL_EventID Left Join
  (Select
    cmn_bpt_sta_absencereasons.Name_DictID,
    cmn_bpt_sta_absencereasons.CMN_BPT_STA_AbsenceReasonID,
    cmn_str_sce_forbiddenleavetypes.CMN_STR_SCE_StructureCalendarEvent_RefID,
    cmn_bpt_sta_absencereasons.IsDeleted,
    cmn_str_sce_forbiddenleavetypes.IsDeleted As IsDeleted1,
    cmn_str_sce_forbiddenleavetypes.CMN_STR_SCE_ForbiddenLeaveTypeID
  From
    cmn_str_sce_forbiddenleavetypes Inner Join
    cmn_bpt_sta_absencereasons
      On cmn_bpt_sta_absencereasons.CMN_BPT_STA_AbsenceReasonID =
      cmn_str_sce_forbiddenleavetypes.CMN_BPT_STA_AbsenceReason_RefID
  Where
    cmn_bpt_sta_absencereasons.IsDeleted = 0 And
    cmn_str_sce_forbiddenleavetypes.IsDeleted = 0) forbidenLeaveTypes
    On cmn_str_sce_structurecalendarevents.CMN_STR_SCE_StructureCalendarEventID
    = forbidenLeaveTypes.CMN_STR_SCE_StructureCalendarEvent_RefID Left Join
  (Select
    cmn_str_sce_capacityrestriction_types.CMN_STR_SCE_CapacityRestriction_TypeID,
    cmn_str_sce_capacityrestriction_types.CapacityRestrictionType_Name_DictID,
    cmn_str_sce_capacityrestrictions.CMN_STR_SCE_CapacityRestrictionID,
    cmn_str_sce_capacityrestrictions.IsValueCalculated_InPercentage,
    cmn_str_sce_capacityrestrictions.IsValueCalculated_InHeadCount,
    cmn_str_sce_capacityrestrictions.IsValueCalculated_InWorkingHours,
    cmn_str_sce_capacityrestrictions.ValueCalculated,
    cmn_str_sce_capacityrestriction_types.IsDeleted,
    cmn_str_sce_capacityrestrictions.IsDeleted As IsDeleted1
  From
    cmn_str_sce_capacityrestriction_types Inner Join
    cmn_str_sce_capacityrestrictions
      On cmn_str_sce_capacityrestrictions.CapacityRestrictionType_RefID =
      cmn_str_sce_capacityrestriction_types.CMN_STR_SCE_CapacityRestriction_TypeID
  Where
    cmn_str_sce_capacityrestriction_types.IsDeleted = 0 And
    cmn_str_sce_capacityrestrictions.IsDeleted = 0) CapacityRestriction
    On CapacityRestriction.CMN_STR_SCE_CapacityRestrictionID =
    cmn_str_sce_structurecalendarevents.IfHavingCapacityRestriction_Restriction_RefID Inner Join
  cmn_str_sce_structurecalendarevent_types
    On cmn_str_sce_structurecalendarevents.StructureCalendarEvent_Type_RefID =
    cmn_str_sce_structurecalendarevent_types.CMN_STR_SCE_StructureCalendarEvent_TypeID
Where
  (cmn_cal_repetition_ranges.IsDeleted = 0 Or
    cmn_cal_repetition_ranges.IsDeleted Is Null) And
  cmn_cal_events.IsDeleted = 0 And
  cmn_str_sce_structurecalendarevents.IsDeleted = 0 And
  cmn_cal_events.Tenant_RefID = @TenantID And
  cmn_str_sce_structurecalendarevent_types.IsDeleted = 0
	  
  