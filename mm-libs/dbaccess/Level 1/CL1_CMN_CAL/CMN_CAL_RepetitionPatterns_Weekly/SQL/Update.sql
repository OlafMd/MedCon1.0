UPDATE 
	cmn_cal_repetitionpatterns_weekly
SET 
	Repetition_RefID=@Repetition_RefID,
	Repetition_EveryNumberOfWeeks=@Repetition_EveryNumberOfWeeks,
	HasRepeatingOn_Mondays=@HasRepeatingOn_Mondays,
	HasRepeatingOn_Tuesdays=@HasRepeatingOn_Tuesdays,
	HasRepeatingOn_Wednesdays=@HasRepeatingOn_Wednesdays,
	HasRepeatingOn_Thursdays=@HasRepeatingOn_Thursdays,
	HasRepeatingOn_Fridays=@HasRepeatingOn_Fridays,
	HasRepeatingOn_Saturdays=@HasRepeatingOn_Saturdays,
	HasRepeatingOn_Sundays=@HasRepeatingOn_Sundays,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_CAL_RepetitionPattern_WeeklyID = @CMN_CAL_RepetitionPattern_WeeklyID