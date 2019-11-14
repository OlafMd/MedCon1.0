UPDATE 
	cmn_str_office_workdays
SET 
	WorkDay_Start=@WorkDay_Start,
	WorkDay_End=@WorkDay_End,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_STR_Office_WorkDayID = @CMN_STR_Office_WorkDayID