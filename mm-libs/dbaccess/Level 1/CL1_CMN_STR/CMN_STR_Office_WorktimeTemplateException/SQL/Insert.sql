INSERT INTO 
	cmn_str_office_worktimetemplateexceptions
	(
		CMN_STR_Office_WorktimeTemplateExceptionID,
		Office_RefID,
		CMN_CAL_Event_RefID,
		Description,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@CMN_STR_Office_WorktimeTemplateExceptionID,
		@Office_RefID,
		@CMN_CAL_Event_RefID,
		@Description,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)