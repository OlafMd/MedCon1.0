INSERT INTO 
	cmn_str_pps_dailyworkschedule_2_shifttemplate
	(
		AssignmentID,
		CMN_STR_PPS_DailyWorkSchedule_RefID,
		CMN_PPS_ShiftTemplate_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@AssignmentID,
		@CMN_STR_PPS_DailyWorkSchedule_RefID,
		@CMN_PPS_ShiftTemplate_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)