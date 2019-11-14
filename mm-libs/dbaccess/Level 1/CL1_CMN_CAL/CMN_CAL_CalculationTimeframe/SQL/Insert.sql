INSERT INTO 
	cmn_cal_calculationtimeframes
	(
		CMN_CAL_CalculationTimeframeID,
		CalculationTimeframe_StartDate,
		CalculationTimefrate_EndDate,
		CalculationTimeframe_EstimatedEndDate,
		IsCalculationTimeframe_Active,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_CAL_CalculationTimeframeID,
		@CalculationTimeframe_StartDate,
		@CalculationTimefrate_EndDate,
		@CalculationTimeframe_EstimatedEndDate,
		@IsCalculationTimeframe_Active,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)