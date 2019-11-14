UPDATE 
	cmn_pps_breaktimes
SET 
	BreakTime_Name_DictID=@BreakTime_Name,
	Default_Duration_in_sec=@Default_Duration_in_sec,
	IsBreakfastBreak=@IsBreakfastBreak,
	IsLunchBreak=@IsLunchBreak,
	IsDinnerBreak=@IsDinnerBreak,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_PPS_BreakTimeID = @CMN_PPS_BreakTimeID