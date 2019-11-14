UPDATE 
	cmn_cal_calendarinstances
SET 
	WeekStartsOnDay=@WeekStartsOnDay,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_CAL_CalendarInstanceID = @CMN_CAL_CalendarInstanceID