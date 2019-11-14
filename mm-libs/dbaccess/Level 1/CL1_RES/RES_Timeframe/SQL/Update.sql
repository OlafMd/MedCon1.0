UPDATE 
	res_timeframes
SET 
	Timeframe_Name_DictID=@Timeframe_Name,
	Timeframe_Description_DictID=@Timeframe_Description,
	Timeframe_SequenceNumber=@Timeframe_SequenceNumber,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_TimeframeID = @RES_TimeframeID