UPDATE 
	cmn_str_pps_workdetail_activities
SET 
	CMN_PPS_ShiftTemplate_WorkDetail_RefID=@CMN_PPS_ShiftTemplate_WorkDetail_RefID,
	CMN_STR_PPS_Workplace_RefID=@CMN_STR_PPS_Workplace_RefID,
	CMN_STR_PPS_Activity_RefID=@CMN_STR_PPS_Activity_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_STR_PPS_WorkDetail_ActivityID = @CMN_STR_PPS_WorkDetail_ActivityID