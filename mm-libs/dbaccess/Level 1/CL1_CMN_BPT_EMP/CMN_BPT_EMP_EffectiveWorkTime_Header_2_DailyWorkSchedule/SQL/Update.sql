UPDATE 
	cmn_bpt_emp_effectiveworktime_header_2_dailyworkschedule
SET 
	CMN_STR_PPS_DailyWorkSchedule_RefID=@CMN_STR_PPS_DailyWorkSchedule_RefID,
	CMN_STR_PPS_EffectiveWorkTime_Header_RefID=@CMN_STR_PPS_EffectiveWorkTime_Header_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID