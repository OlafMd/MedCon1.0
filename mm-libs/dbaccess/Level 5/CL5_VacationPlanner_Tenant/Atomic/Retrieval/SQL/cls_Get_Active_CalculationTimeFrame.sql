
	Select
	  cmn_cal_calculationtimeframes.CMN_CAL_CalculationTimeframeID,
	  cmn_cal_calculationtimeframes.CalculationTimeframe_StartDate,
	  cmn_cal_calculationtimeframes.CalculationTimefrate_EndDate,
	  cmn_cal_calculationtimeframes.CalculationTimeframe_EstimatedEndDate,
	  cmn_cal_calculationtimeframes.IsCalculationTimeframe_Active
	From
	  cmn_cal_calculationtimeframes
	Where
	  cmn_cal_calculationtimeframes.IsCalculationTimeframe_Active = 1 And
	  cmn_cal_calculationtimeframes.Tenant_RefID = @TenantID And
	  cmn_cal_calculationtimeframes.IsDeleted = 0
  