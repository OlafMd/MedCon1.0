
	Select
  cmn_bpt_str_workarea_settingsprofiles.CMN_BPT_STR_Workarea_SettingsProfileID,
  cmn_bpt_str_workarea_settingsprofiles.Workarea_RefID,
  cmn_bpt_str_workarea_settingsprofiles.WorkdayStart_in_mins,
  cmn_bpt_str_workarea_settingsprofiles.RoosterGridMinimumPlanningUnit_in_mins,
  cmn_bpt_str_workarea_settingsprofiles.MaximumPreWork_Period_in_mins,
  cmn_bpt_str_workarea_settingsprofiles.MaximumPostWork_Period_in_mins
From
  cmn_bpt_str_workarea_settingsprofiles
Where
  cmn_bpt_str_workarea_settingsprofiles.Tenant_RefID = @TenantID And
  cmn_bpt_str_workarea_settingsprofiles.IsDeleted = 0
  