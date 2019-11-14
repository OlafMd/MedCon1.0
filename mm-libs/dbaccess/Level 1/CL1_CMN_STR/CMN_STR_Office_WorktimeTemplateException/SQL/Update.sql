UPDATE 
	cmn_str_office_worktimetemplateexceptions
SET 
	Office_RefID=@Office_RefID,
	CMN_CAL_Event_RefID=@CMN_CAL_Event_RefID,
	Description=@Description,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_STR_Office_WorktimeTemplateExceptionID = @CMN_STR_Office_WorktimeTemplateExceptionID