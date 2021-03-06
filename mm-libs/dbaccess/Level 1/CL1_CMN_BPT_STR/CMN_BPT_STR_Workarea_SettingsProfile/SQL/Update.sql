UPDATE 
	cmn_bpt_str_workarea_settingsprofiles
SET 
	Workarea_RefID=@Workarea_RefID,
	WorkdayStart_in_mins=@WorkdayStart_in_mins,
	RoosterGridMinimumPlanningUnit_in_mins=@RoosterGridMinimumPlanningUnit_in_mins,
	MaximumPreWork_Period_in_mins=@MaximumPreWork_Period_in_mins,
	MaximumPostWork_Period_in_mins=@MaximumPostWork_Period_in_mins,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_BPT_STR_Workarea_SettingsProfileID = @CMN_BPT_STR_Workarea_SettingsProfileID