UPDATE 
	cmn_bpt_emp_employmentrelationship_templates
SET 
	Template_StartDate=@Template_StartDate,
	Template_EndDate=@Template_EndDate,
	Template_Name_DictID=@Template_Name,
	RequiredMonthlyHours=@RequiredMonthlyHours,
	RequiredWeeklyHours=@RequiredWeeklyHours,
	RequiredDailyHours=@RequiredDailyHours,
	R_WeeklyWorkPattern=@R_WeeklyWorkPattern,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_BPT_EMP_EmploymentRelationship_TemplateID = @CMN_BPT_EMP_EmploymentRelationship_TemplateID