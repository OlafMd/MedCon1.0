INSERT INTO 
	cmn_cal_calendarinstances
	(
		CMN_CAL_CalendarInstanceID,
		WeekStartsOnDay,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_CAL_CalendarInstanceID,
		@WeekStartsOnDay,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)