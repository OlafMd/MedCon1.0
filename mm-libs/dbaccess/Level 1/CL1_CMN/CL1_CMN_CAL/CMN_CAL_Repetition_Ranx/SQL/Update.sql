UPDATE 
	cmn_cal_repetition_ranges
SET 
	Repetition_RefID=@Repetition_RefID,
	StartDate=@StartDate,
	HasEndType_Occurrence=@HasEndType_Occurrence,
	HasEndType_DateTime=@HasEndType_DateTime,
	HasEndType_NoEndDate=@HasEndType_NoEndDate,
	End_AfterSpecifiedOccurrences=@End_AfterSpecifiedOccurrences,
	End_ByDate=@End_ByDate,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_CAL_Repetition_RangeID = @CMN_CAL_Repetition_RangeID