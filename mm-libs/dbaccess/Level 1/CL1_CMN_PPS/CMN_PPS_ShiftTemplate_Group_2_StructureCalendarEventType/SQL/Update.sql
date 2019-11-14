UPDATE 
	cmn_pps_shifttemplate_group_2_structurecalendareventtype
SET 
	CMN_STR_SCE_StructureCalendarEvent_Type_RefID=@CMN_STR_SCE_StructureCalendarEvent_Type_RefID,
	CMN_PPS_ShiftTemplate_Group_RefID=@CMN_PPS_ShiftTemplate_Group_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	AssignmentID = @AssignmentID