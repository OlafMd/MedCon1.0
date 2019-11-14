UPDATE 
	cmn_str_pps_dailyworkschedule_details
SET 
	InstantiatedWithShiftTemplate_RefID=@InstantiatedWithShiftTemplate_RefID,
	CMN_CAL_Event_RefID=@CMN_CAL_Event_RefID,
	DailyWorkSchedule_RefID=@DailyWorkSchedule_RefID,
	AbsenceReason_RefID=@AbsenceReason_RefID,
	SheduleForWorkplace_RefID=@SheduleForWorkplace_RefID,
	IsWorkBreak=@IsWorkBreak,
	CMN_BPT_EMP_Employee_LeaveRequest_RefID=@CMN_BPT_EMP_Employee_LeaveRequest_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_STR_PPS_DailyWorkSchedule_DetailID = @CMN_STR_PPS_DailyWorkSchedule_DetailID