INSERT INTO 
	cmn_cal_repetitionpatterns_daily
	(
		CMN_CAL_RepetitionPattern_DailyID,
		RepeatOnlyOnWorkdays,
		Repetition_RefID,
		Repetition_EveryNumberOfDays,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_CAL_RepetitionPattern_DailyID,
		@RepeatOnlyOnWorkdays,
		@Repetition_RefID,
		@Repetition_EveryNumberOfDays,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)