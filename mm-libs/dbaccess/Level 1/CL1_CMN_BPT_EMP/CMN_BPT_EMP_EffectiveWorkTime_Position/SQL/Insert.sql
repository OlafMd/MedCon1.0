INSERT INTO 
	cmn_bpt_emp_effectiveworktime_positions
	(
		CMN_BPT_EMP_EffectiveWorkTime_PositionID,
		EffectiveWorkTime_Header_RefID,
		CMN_BPT_EMP_Employe_RefID,
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
		@CMN_BPT_EMP_EffectiveWorkTime_PositionID,
		@EffectiveWorkTime_Header_RefID,
		@CMN_BPT_EMP_Employe_RefID,
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