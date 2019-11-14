UPDATE 
	cmn_pps_breaktime_defaults
SET 
	BreakTime_Template_RefID=@BreakTime_Template_RefID,
	ExpectedWorkTime_in_sec=@ExpectedWorkTime_in_sec,
	ValidFromTimeOffset_in_sec=@ValidFromTimeOffset_in_sec,
	ValidToTimeOffset_in_sec=@ValidToTimeOffset_in_sec,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_PPS_BreakTime_DefaultID = @CMN_PPS_BreakTime_DefaultID