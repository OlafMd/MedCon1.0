
Select
  cmn_str_offices.CMN_STR_OfficeID As OfficeID,
  cmn_str_offices.Office_Name_DictID,
  cmn_addresses.Street_Name,
  cmn_addresses.Street_Number,
  cmn_addresses.City_Name,
  cmn_cal_weeklyofficehours_intervals.TimeFrom_InMinutes,
  cmn_cal_weeklyofficehours_intervals.TimeTo_InMinutes,
  cmn_cal_weeklyofficehours_intervals.IsMonday,
  cmn_cal_weeklyofficehours_intervals.IsTuesday,
  cmn_cal_weeklyofficehours_intervals.IsWednesday,
  cmn_cal_weeklyofficehours_intervals.IsThursday,
  cmn_cal_weeklyofficehours_intervals.IsFriday,
  cmn_cal_weeklyofficehours_intervals.CMN_CAL_WeeklyOfficeHours_IntervalID,
  pps_tsk_task_template_organizationalunitavailabilities.PPS_TSK_Task_Template_RefID As AppointmentTypeID
From
  cmn_str_offices Inner Join
  cmn_str_office_addresses On cmn_str_offices.CMN_STR_OfficeID =
    cmn_str_office_addresses.Office_RefID And
    cmn_str_office_addresses.Tenant_RefID = @TenantID And
    cmn_str_office_addresses.IsDeleted = 0 And
    cmn_str_office_addresses.IsDefault = 1 Inner Join
  cmn_addresses On cmn_addresses.CMN_AddressID =
    cmn_str_office_addresses.CMN_Address_RefID And cmn_addresses.IsDeleted = 0
    And cmn_addresses.Tenant_RefID = @TenantID Inner Join
  cmn_str_office_weekly_worktimetemplates On cmn_str_offices.CMN_STR_OfficeID =
    cmn_str_office_weekly_worktimetemplates.Office_RefID And
    cmn_str_office_weekly_worktimetemplates.IsDeleted = 0 And
    cmn_str_office_weekly_worktimetemplates.Tenant_RefID = @TenantID Inner Join
  cmn_cal_weeklyofficehours_intervals
    On
    cmn_str_office_weekly_worktimetemplates.CMN_CAL_WeeklyOfficeHours_Interval_RefID = cmn_cal_weeklyofficehours_intervals.CMN_CAL_WeeklyOfficeHours_IntervalID And cmn_cal_weeklyofficehours_intervals.Tenant_RefID = @TenantID And cmn_cal_weeklyofficehours_intervals.IsDeleted = 0 Inner Join
  pps_tsk_task_template_organizationalunitavailabilities
    On
    pps_tsk_task_template_organizationalunitavailabilities.CMN_STR_Office_RefID
    = cmn_str_offices.CMN_STR_OfficeID      And
  pps_tsk_task_template_organizationalunitavailabilities.Tenant_RefID =
  @TenantID And
  pps_tsk_task_template_organizationalunitavailabilities.IsDeleted = 0
Where
  cmn_str_offices.Tenant_RefID = @TenantID And
  cmn_str_offices.IsDeleted = 0 
  