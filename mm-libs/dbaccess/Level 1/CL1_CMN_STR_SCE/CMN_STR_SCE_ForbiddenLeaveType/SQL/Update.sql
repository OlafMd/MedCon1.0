UPDATE 
	cmn_str_sce_forbiddenleavetypes
SET 
	CMN_STR_SCE_StructureCalendarEvent_RefID=@CMN_STR_SCE_StructureCalendarEvent_RefID,
	CMN_BPT_STA_AbsenceReason_RefID=@CMN_BPT_STA_AbsenceReason_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_STR_SCE_ForbiddenLeaveTypeID = @CMN_STR_SCE_ForbiddenLeaveTypeID