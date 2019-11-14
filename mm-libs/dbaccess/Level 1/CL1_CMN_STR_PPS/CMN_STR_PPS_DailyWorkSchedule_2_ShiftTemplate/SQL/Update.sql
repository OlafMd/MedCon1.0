UPDATE 
	cmn_str_pps_dailyworkschedule_2_shifttemplate
SET 
	CMN_STR_PPS_DailyWorkSchedule_RefID=@CMN_STR_PPS_DailyWorkSchedule_RefID,
	CMN_PPS_ShiftTemplate_RefID=@CMN_PPS_ShiftTemplate_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	AssignmentID = @AssignmentID