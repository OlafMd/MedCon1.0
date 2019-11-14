INSERT INTO 
	cmn_str_pps_effectiveworktimes
	(
		CMN_STR_PPS_EffectiveWorkTimeID,
		CMN_BPT_EMP_Employe_RefID,
		BoundTo_DailyWorkShedule_Detail_RefID,
		Activity_RefID,
		Workplace_RefID,
		CMN_BPT_EMP_Employee_LeaveRequest_RefID,
		WorkTime_StartTime,
		WorkTime_Duration_in_sec,
		SourceOfEntry,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@CMN_STR_PPS_EffectiveWorkTimeID,
		@CMN_BPT_EMP_Employe_RefID,
		@BoundTo_DailyWorkShedule_Detail_RefID,
		@Activity_RefID,
		@Workplace_RefID,
		@CMN_BPT_EMP_Employee_LeaveRequest_RefID,
		@WorkTime_StartTime,
		@WorkTime_Duration_in_sec,
		@SourceOfEntry,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)