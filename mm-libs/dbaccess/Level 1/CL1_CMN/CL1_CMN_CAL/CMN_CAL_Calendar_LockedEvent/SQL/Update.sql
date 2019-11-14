UPDATE 
	cmn_cal_calendar_lockedevents
SET 
	Calendar_LockPeriod_RefID=@Calendar_LockPeriod_RefID,
	Calendar_Event_RefID=@Calendar_Event_RefID,
	EventCreatedForLockPeriod=@EventCreatedForLockPeriod,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_CAL_Calendar_LockedEventID = @CMN_CAL_Calendar_LockedEventID