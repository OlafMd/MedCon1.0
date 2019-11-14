UPDATE 
	cmn_bpt_investedworktimes
SET 
	BusinessParticipant_RefID=@BusinessParticipant_RefID,
	ChargingLevel_RefID=@ChargingLevel_RefID,
	WorkTime_InternalIdentifier=@WorkTime_InternalIdentifier,
	WorkTime_Source=@WorkTime_Source,
	WorkTime_Comment_DictID=@WorkTime_Comment,
	WorkTime_Amount_min=@WorkTime_Amount_min,
	WorkTime_Start=@WorkTime_Start,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_BPT_InvestedWorkTimeID = @CMN_BPT_InvestedWorkTimeID