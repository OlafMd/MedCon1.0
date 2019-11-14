
	Select
	  cmn_bpt_sta_settingprofiles.CMN_BPT_STA_SettingProfileID,
	  cmn_bpt_sta_settingprofiles.IsLeaveTimeCalculated_InDays,
	  cmn_bpt_sta_settingprofiles.StafMember_Caption_DictID,
	  cmn_bpt_sta_settingprofiles.IsLeaveTimeCalculated_InHours,
	  cmn_bpt_sta_settingprofiles.IsUsingWorkflow_ForLeaveRequests,
	  cmn_bpt_sta_settingprofiles.Default_AdulthoodAge,
	  cmn_bpt_sta_settingprofiles.Default_RestWarningThreshold_Adults_in_mins,
	  cmn_bpt_sta_settingprofiles.Default_RestWarningThreshold_NonAdults_in_mins,
	  cmn_bpt_sta_settingprofiles.Default_RestMinimumThresholdl_Adults_in_mins,
	  cmn_bpt_sta_settingprofiles.Default_RestMinimumThresholdl_NonAdults_in_mins,
	  cmn_bpt_sta_settingprofiles.Default_WorkTimeWarningTreshold_Adults_in_mins,
	  cmn_bpt_sta_settingprofiles.Default_WorkTimeWarningTreshold_NonAdults_in_mins,
	  cmn_bpt_sta_settingprofiles.Default_WorkTimeMaximumTreshold_Adults_in_mins,
	  cmn_bpt_sta_settingprofiles.Default_WorkTimeMaximumTreshold_NonAdults_in_mins,
	  cmn_bpt_sta_settingprofiles.Default_WorkStartTimeWarning_NonAdults_in_mins,
	  cmn_bpt_sta_settingprofiles.Default_WorkStartTimeMinimum_NonAdults_in_mins,
	  cmn_bpt_sta_settingprofiles.Default_WorkEndTimeWarning_NonAdults_in_mins,
	  cmn_bpt_sta_settingprofiles.Default_WorktimeBalancePeriod_in_months,
	  cmn_bpt_sta_settingprofiles.Default_WorkEndTimeMaximum_NonAdults_in_mins,
	  cmn_bpt_sta_settingprofiles.Default_WorkdayStart_in_mins,
	  cmn_bpt_sta_settingprofiles.Default_RoosterGridMinimumPlanningUnit_in_mins,
	  cmn_bpt_sta_settingprofiles.Default_MaximumPreWork_Period_in_mins,
	  cmn_bpt_sta_settingprofiles.Default_MaximumPostWork_Period_in_mins,
	  cmn_bpt_sta_settingprofiles.Default_SurchargeCalculation_UseMaximum,
	  cmn_bpt_sta_settingprofiles.Default_SurchargeCalculation_UseAccumulated
	From
	  cmn_bpt_sta_settingprofiles
	Where
	  cmn_bpt_sta_settingprofiles.IsDeleted = 0 And
	  cmn_bpt_sta_settingprofiles.Tenant_RefID = @TenantID
  