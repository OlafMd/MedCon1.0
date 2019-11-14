UPDATE 
	cmn_pps_breaktime_templates
SET 
	BoundTo_Office_RefID=@BoundTo_Office_RefID,
	BoundTo_Workarea_RefID=@BoundTo_Workarea_RefID,
	BoundTo_Workplace_RefID=@BoundTo_Workplace_RefID,
	BreakTimeTemplate_Name_DictID=@BreakTimeTemplate_Name,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_PPS_BreakTime_TemplateID = @CMN_PPS_BreakTime_TemplateID