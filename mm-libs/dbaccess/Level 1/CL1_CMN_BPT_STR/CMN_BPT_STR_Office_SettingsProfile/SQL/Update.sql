UPDATE 
	cmn_bpt_str_office_settingsprofile
SET 
	Office_RefID=@Office_RefID,
	AdulthoodAge=@AdulthoodAge,
	RestWarningThreshold_Adults_in_mins=@RestWarningThreshold_Adults_in_mins,
	RestWarningThreshold_NonAdults_in_mins=@RestWarningThreshold_NonAdults_in_mins,
	RestMinimumThresholdl_Adults_in_mins=@RestMinimumThresholdl_Adults_in_mins,
	RestMinimumThresholdl_NonAdults_in_mins=@RestMinimumThresholdl_NonAdults_in_mins,
	WorkTimeWarningTreshold_Adults_in_mins=@WorkTimeWarningTreshold_Adults_in_mins,
	WorkTimeWarningTreshold_NonAdults_in_mins=@WorkTimeWarningTreshold_NonAdults_in_mins,
	WorkTimeMaximumTreshold_Adults_in_mins=@WorkTimeMaximumTreshold_Adults_in_mins,
	WorkTimeMaximumTreshold_NonAdults_in_mins=@WorkTimeMaximumTreshold_NonAdults_in_mins,
	WorkStartTimeWarning_NonAdults_in_mins=@WorkStartTimeWarning_NonAdults_in_mins,
	WorkStartTimeMinimum_NonAdults_in_mins=@WorkStartTimeMinimum_NonAdults_in_mins,
	WorkEndTimeWarning_NonAdults_in_mins=@WorkEndTimeWarning_NonAdults_in_mins,
	WorkEndTimeMaximum_NonAdults_in_mins=@WorkEndTimeMaximum_NonAdults_in_mins,
	WorktimeBalancePeriod_in_months=@WorktimeBalancePeriod_in_months,
	WorkdayStart_in_mins=@WorkdayStart_in_mins,
	RoosterGridMinimumPlanningUnit_in_mins=@RoosterGridMinimumPlanningUnit_in_mins,
	MaximumPreWork_Period_in_mins=@MaximumPreWork_Period_in_mins,
	MaximumPostWork_Period_in_mins=@MaximumPostWork_Period_in_mins,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_BPT_STR_Office_SettingsProfileID = @CMN_BPT_STR_Office_SettingsProfileID