UPDATE 
	cmn_str_pps_effectiveworktimes
SET 
	CMN_BPT_EMP_Employe_RefID=@CMN_BPT_EMP_Employe_RefID,
	BoundTo_DailyWorkShedule_Detail_RefID=@BoundTo_DailyWorkShedule_Detail_RefID,
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
	CMN_STR_PPS_EffectiveWorkTimeID = @CMN_STR_PPS_EffectiveWorkTimeID