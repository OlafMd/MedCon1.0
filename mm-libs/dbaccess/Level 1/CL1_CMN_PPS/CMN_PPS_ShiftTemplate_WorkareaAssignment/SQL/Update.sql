UPDATE 
	cmn_pps_shifttemplate_workareaassignments
SET 
	CMN_PPS_ShiftTemplate_RefID=@CMN_PPS_ShiftTemplate_RefID,
	CMN_BPT_PPS_WorkArea_RefID=@CMN_BPT_PPS_WorkArea_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_PPS_ShiftTemplate_WorkareaAssignmentID = @CMN_PPS_ShiftTemplate_WorkareaAssignmentID