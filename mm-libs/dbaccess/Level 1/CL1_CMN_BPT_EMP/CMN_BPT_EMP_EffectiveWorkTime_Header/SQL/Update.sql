UPDATE 
	cmn_bpt_emp_effectiveworktime_headers
SET 
	Employee_RefID=@Employee_RefID,
	EffectiveBusinessDay=@EffectiveBusinessDay,
	SheduleBreakTemplate_RefID=@SheduleBreakTemplate_RefID,
	IsBreakTimeManualySpecified=@IsBreakTimeManualySpecified,
	BreakDurationTime_in_sec=@BreakDurationTime_in_sec,
	WorktimeComment=@WorktimeComment,
	ContractWorkerText=@ContractWorkerText,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_STR_PPS_EffectiveWorkTime_HeaderID = @CMN_STR_PPS_EffectiveWorkTime_HeaderID