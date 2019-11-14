UPDATE 
	cmn_str_office_weekly_worktimetemplates
SET 
	Office_RefID=@Office_RefID,
	CMN_CAL_WeeklyOfficeHours_Interval_RefID=@CMN_CAL_WeeklyOfficeHours_Interval_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_STR_Office_Weekly_WorkTimeTemplateID = @CMN_STR_Office_Weekly_WorkTimeTemplateID