UPDATE 
	cmn_cal_weeklyofficehours_templates
SET 
	OfficeHoursTemplate_Name=@OfficeHoursTemplate_Name,
	FormattedOfficeHours=@FormattedOfficeHours,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_CAL_WeeklyOfficeHours_TemplateID = @CMN_CAL_WeeklyOfficeHours_TemplateID