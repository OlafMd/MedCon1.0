UPDATE 
	cmn_bpt_emp_effectiveworktime_positions
SET 
	EffectiveWorkTime_Header_RefID=@EffectiveWorkTime_Header_RefID,
	CMN_BPT_EMP_Employe_RefID=@CMN_BPT_EMP_Employe_RefID,
	Activity_RefID=@Activity_RefID,
	Workplace_RefID=@Workplace_RefID,
	CMN_BPT_EMP_Employee_LeaveRequest_RefID=@CMN_BPT_EMP_Employee_LeaveRequest_RefID,
	WorkTime_StartTime=@WorkTime_StartTime,
	WorkTime_Duration_in_sec=@WorkTime_Duration_in_sec,
	SourceOfEntry=@SourceOfEntry,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_BPT_EMP_EffectiveWorkTime_PositionID = @CMN_BPT_EMP_EffectiveWorkTime_PositionID