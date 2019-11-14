UPDATE 
	cmn_str_pps_shiftplan_day_shifttemplates
SET 
	CMN_PPS_ShiftTemplate_RefID=@CMN_PPS_ShiftTemplate_RefID,
	CMN_STR_PPS_ShiftPlan_Day_RefID=@CMN_STR_PPS_ShiftPlan_Day_RefID,
	RequiredHeadCount=@RequiredHeadCount,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_STR_PPS_ShiftPlan_Day_ShiftTemplateID = @CMN_STR_PPS_ShiftPlan_Day_ShiftTemplateID