
	Select
	  res_timeframes.RES_TimeframeID,
	  res_timeframes.Timeframe_Name_DictID,
	  res_timeframes.Timeframe_Description_DictID,
	  res_timeframes.Timeframe_SequenceNumber,
	  res_timeframes.IsDeleted,
	  res_timeframes.Tenant_RefID
	From
	  res_timeframes
	Where
	  res_timeframes.IsDeleted = 0 And
	  res_timeframes.Tenant_RefID = @TenantID
  