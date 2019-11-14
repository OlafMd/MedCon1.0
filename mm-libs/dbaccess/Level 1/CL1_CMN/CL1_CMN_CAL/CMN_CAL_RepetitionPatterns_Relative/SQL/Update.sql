UPDATE 
	cmn_cal_repetitionpatterns_relative
SET 
	Ordinal=@Ordinal,
	IsWeekDay=@IsWeekDay,
	IsWeekendDay=@IsWeekendDay,
	IsMonday=@IsMonday,
	IsTuesday=@IsTuesday,
	IsWednesday=@IsWednesday,
	IsThursday=@IsThursday,
	IsFriday=@IsFriday,
	IsSaturday=@IsSaturday,
	IsSunday=@IsSunday,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_CAL_RepetitionPattern_RelativeID = @CMN_CAL_RepetitionPattern_RelativeID