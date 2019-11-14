UPDATE 
	tms_quicktask_investedworktimes
SET 
	TMS_QuickTasks_RefID=@TMS_QuickTasks_RefID,
	CMN_BPT_InvestedWorkTime_RefID=@CMN_BPT_InvestedWorkTime_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	TMS_QuickTask_InvestedWorkTimeID = @TMS_QuickTask_InvestedWorkTimeID