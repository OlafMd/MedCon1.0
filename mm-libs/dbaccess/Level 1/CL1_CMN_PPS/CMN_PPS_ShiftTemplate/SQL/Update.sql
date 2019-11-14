UPDATE 
	cmn_pps_shifttemplates
SET 
	ShiftTemplate_ShortName=@ShiftTemplate_ShortName,
	ShiftTemplate_Name_DictID=@ShiftTemplate_Name,
	CMN_STR_Office_RefID=@CMN_STR_Office_RefID,
	CMN_STR_Workarea_RefID=@CMN_STR_Workarea_RefID,
	CMN_STR_Workplace_RefID=@CMN_STR_Workplace_RefID,
	Default_StartTime_in_sec=@Default_StartTime_in_sec,
	IsWorkPattern=@IsWorkPattern,
	Default_AllowedBreakTimeTemplate_RefID=@Default_AllowedBreakTimeTemplate_RefID,
	DisplayColor=@DisplayColor,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_PPS_ShiftTemplateID = @CMN_PPS_ShiftTemplateID