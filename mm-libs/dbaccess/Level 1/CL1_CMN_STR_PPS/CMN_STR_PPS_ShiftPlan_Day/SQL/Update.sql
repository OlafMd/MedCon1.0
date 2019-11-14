UPDATE 
	cmn_str_pps_shiftplan_days
SET 
	ShiftPlanDay=@ShiftPlanDay,
	IsVisibleToEmployees=@IsVisibleToEmployees,
	IsEmployeeRegistrationAllowed=@IsEmployeeRegistrationAllowed,
	IfEmployeeRegistrationAllowed_DueDate=@IfEmployeeRegistrationAllowed_DueDate,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_STR_PPS_ShiftPlan_DayID = @CMN_STR_PPS_ShiftPlan_DayID