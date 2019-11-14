
Select
  cmn_cal_calendar_lockperiods.CMN_CAL_Calendar_LockPeriodID,
  cmn_cal_calendar_lockperiods.LockPeriod_FromDate,
  cmn_cal_calendar_lockperiods.LockPeriod_ToDate,
  cmn_cal_calendar_lockperiods.LockPeriod_Comment
From
  cmn_cal_calendar_lockperiods
Where
  cmn_cal_calendar_lockperiods.IsUnlocked = 1 And
  cmn_cal_calendar_lockperiods.Tenant_RefID = @TenantID And
  cmn_cal_calendar_lockperiods.IsDeleted = 0
  