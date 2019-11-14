
	Select
  cmn_str_office_weekly_worktimetemplates.Office_RefID,
  cmn_str_office_weekly_worktimetemplates.CMN_STR_Office_Weekly_WorkTimeTemplateID As TimeID,
  cmn_cal_weeklyofficehours_intervals.IsWholeDay,
  cmn_cal_weeklyofficehours_intervals.TimeFrom_InMinutes,
  cmn_cal_weeklyofficehours_intervals.TimeTo_InMinutes,
  cmn_cal_weeklyofficehours_intervals.IsMonday,
  cmn_cal_weeklyofficehours_intervals.IsTuesday,
  cmn_cal_weeklyofficehours_intervals.IsWednesday,
  cmn_cal_weeklyofficehours_intervals.IsThursday,
  cmn_cal_weeklyofficehours_intervals.IsFriday,
  cmn_cal_weeklyofficehours_intervals.IsSaturday,
  cmn_cal_weeklyofficehours_intervals.IsSunday,
  cmn_cal_weeklyofficehours_templates.OfficeHoursTemplate_Name
From
  cmn_str_office_weekly_worktimetemplates Inner Join
  cmn_cal_weeklyofficehours_intervals
    On
    cmn_str_office_weekly_worktimetemplates.CMN_CAL_WeeklyOfficeHours_Interval_RefID = cmn_cal_weeklyofficehours_intervals.CMN_CAL_WeeklyOfficeHours_IntervalID And cmn_cal_weeklyofficehours_intervals.IsDeleted = 0 And cmn_cal_weeklyofficehours_intervals.Tenant_RefID = @TenantID Inner Join
  cmn_cal_weeklyofficehours_templates
    On cmn_cal_weeklyofficehours_intervals.WeeklyOfficeHours_Template_RefID =
    cmn_cal_weeklyofficehours_templates.CMN_CAL_WeeklyOfficeHours_TemplateID And
    cmn_cal_weeklyofficehours_templates.IsDeleted = 0 And
    cmn_cal_weeklyofficehours_templates.Tenant_RefID = @TenantID
Where
  cmn_str_office_weekly_worktimetemplates.IsDeleted = 0 And
  cmn_str_office_weekly_worktimetemplates.Tenant_RefID = @TenantID And
  cmn_str_office_weekly_worktimetemplates.Office_RefID = @OfficeID    
Order By
  cmn_str_office_weekly_worktimetemplates.Creation_Timestamp
  