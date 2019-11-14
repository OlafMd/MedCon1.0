UPDATE 
	cmn_cal_repetitionpatterns_daily
SET 
	RepeatOnlyOnWorkdays=@RepeatOnlyOnWorkdays,
	Repetition_RefID=@Repetition_RefID,
	Repetition_EveryNumberOfDays=@Repetition_EveryNumberOfDays,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_CAL_RepetitionPattern_DailyID = @CMN_CAL_RepetitionPattern_DailyID