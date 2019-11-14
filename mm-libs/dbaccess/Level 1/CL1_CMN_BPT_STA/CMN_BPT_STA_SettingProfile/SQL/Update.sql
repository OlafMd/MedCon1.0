UPDATE 
	cmn_bpt_sta_settingprofiles
SET 
	StafMember_Caption_DictID=@StafMember_Caption,
	IsLeaveTimeCalculated_InDays=@IsLeaveTimeCalculated_InDays,
	IsLeaveTimeCalculated_InHours=@IsLeaveTimeCalculated_InHours,
	IsUsingWorkflow_ForLeaveRequests=@IsUsingWorkflow_ForLeaveRequests,
	Default_AdulthoodAge=@Default_AdulthoodAge,
	Default_SurchargeCalculation_UseMaximum=@Default_SurchargeCalculation_UseMaximum,
	Default_SurchargeCalculation_UseAccumulated=@Default_SurchargeCalculation_UseAccumulated,
	Default_RestWarningThreshold_Adults_in_mins=@Default_RestWarningThreshold_Adults_in_mins,
	Default_RestWarningThreshold_NonAdults_in_mins=@Default_RestWarningThreshold_NonAdults_in_mins,
	Default_RestMinimumThresholdl_Adults_in_mins=@Default_RestMinimumThresholdl_Adults_in_mins,
	Default_RestMinimumThresholdl_NonAdults_in_mins=@Default_RestMinimumThresholdl_NonAdults_in_mins,
	Default_WorkTimeWarningTreshold_Adults_in_mins=@Default_WorkTimeWarningTreshold_Adults_in_mins,
	Default_WorkTimeWarningTreshold_NonAdults_in_mins=@Default_WorkTimeWarningTreshold_NonAdults_in_mins,
	Default_WorkTimeMaximumTreshold_Adults_in_mins=@Default_WorkTimeMaximumTreshold_Adults_in_mins,
	Default_WorkTimeMaximumTreshold_NonAdults_in_mins=@Default_WorkTimeMaximumTreshold_NonAdults_in_mins,
	Default_WorkStartTimeWarning_NonAdults_in_mins=@Default_WorkStartTimeWarning_NonAdults_in_mins,
	Default_WorkStartTimeMinimum_NonAdults_in_mins=@Default_WorkStartTimeMinimum_NonAdults_in_mins,
	Default_WorkEndTimeWarning_NonAdults_in_mins=@Default_WorkEndTimeWarning_NonAdults_in_mins,
	Default_WorkEndTimeMaximum_NonAdults_in_mins=@Default_WorkEndTimeMaximum_NonAdults_in_mins,
	Default_WorktimeBalancePeriod_in_months=@Default_WorktimeBalancePeriod_in_months,
	Default_WorkdayStart_in_mins=@Default_WorkdayStart_in_mins,
	Default_RoosterGridMinimumPlanningUnit_in_mins=@Default_RoosterGridMinimumPlanningUnit_in_mins,
	Default_MaximumPreWork_Period_in_mins=@Default_MaximumPreWork_Period_in_mins,
	Default_MaximumPostWork_Period_in_mins=@Default_MaximumPostWork_Period_in_mins,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_BPT_STA_SettingProfileID = @CMN_BPT_STA_SettingProfileID