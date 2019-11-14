UPDATE 
	cmn_cal_events
SET 
	CalendarInstance_RefID=@CalendarInstance_RefID,
	Repetition_RefID=@Repetition_RefID,
	IsRepetitive=@IsRepetitive,
	IsWholeDayEvent=@IsWholeDayEvent,
	StartTime=@StartTime,
	EndTime=@EndTime,
	R_EventDuration_sec=@R_EventDuration_sec,
	IsCalendarEvent_Editable=@IsCalendarEvent_Editable,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_CAL_EventID = @CMN_CAL_EventID