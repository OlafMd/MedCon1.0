UPDATE 
	cmn_bpt_sta_staffings
SET 
	Employee_RefID=@Employee_RefID,
	CMN_STR_PPS_Shift_CapacityRequirement_RefID=@CMN_STR_PPS_Shift_CapacityRequirement_RefID,
	StartDate=@StartDate,
	Duration_min=@Duration_min,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_BPT_STA_StaffingID = @CMN_BPT_STA_StaffingID