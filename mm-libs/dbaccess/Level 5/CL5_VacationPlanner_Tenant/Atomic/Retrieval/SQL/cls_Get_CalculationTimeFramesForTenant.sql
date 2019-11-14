
Select
  cmn_cal_calculationtimeframes.CMN_CAL_CalculationTimeframeID,
  cmn_cal_calculationtimeframes.CalculationTimeframe_StartDate,
  cmn_cal_calculationtimeframes.CalculationTimefrate_EndDate,
  cmn_cal_calculationtimeframes.CalculationTimeframe_EstimatedEndDate,
  cmn_cal_calculationtimeframes.IsCalculationTimeframe_Active,
  cmn_cal_calculationtimeframes.Creation_Timestamp
From
  cmn_cal_calculationtimeframes
Where
  cmn_cal_calculationtimeframes.IsDeleted = 0 And
  cmn_cal_calculationtimeframes.Tenant_RefID = @TenantID
  