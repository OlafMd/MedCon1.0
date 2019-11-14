UPDATE 
	cmn_cal_repetitionpatterns_monthly
SET 
	Repetition_RefID=@Repetition_RefID,
	Repetition_EveryNumberOfMonths=@Repetition_EveryNumberOfMonths,
	IsFixed=@IsFixed,
	IsRelative=@IsRelative,
	IfRelative_RepetitionPattern_RefID=@IfRelative_RepetitionPattern_RefID,
	IfFixed_DayOfMonth=@IfFixed_DayOfMonth,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_CAL_RepetitionPattern_MonthlyID = @CMN_CAL_RepetitionPattern_MonthlyID