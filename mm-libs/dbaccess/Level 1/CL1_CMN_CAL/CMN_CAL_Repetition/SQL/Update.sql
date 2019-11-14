UPDATE 
	cmn_cal_repetitions
SET 
	R_CronExpression=@R_CronExpression,
	IsDaily=@IsDaily,
	IsWeekly=@IsWeekly,
	IsMonthly=@IsMonthly,
	IsYearly=@IsYearly,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_CAL_RepetitionID = @CMN_CAL_RepetitionID