UPDATE 
	cmn_cal_calendar_lockperiods
SET 
	LockPeriod_FromDate=@LockPeriod_FromDate,
	LockPeriod_ToDate=@LockPeriod_ToDate,
	LockPeriod_Comment=@LockPeriod_Comment,
	LockPeriod_LockedByAccount_RefID=@LockPeriod_LockedByAccount_RefID,
	IsUnlocked=@IsUnlocked,
	UnlockedBy_Account_RefID=@UnlockedBy_Account_RefID,
	ReasonForUnlocking=@ReasonForUnlocking,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_CAL_Calendar_LockPeriodID = @CMN_CAL_Calendar_LockPeriodID