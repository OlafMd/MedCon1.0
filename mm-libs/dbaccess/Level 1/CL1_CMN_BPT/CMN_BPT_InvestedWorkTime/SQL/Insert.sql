INSERT INTO 
	cmn_bpt_investedworktimes
	(
		CMN_BPT_InvestedWorkTimeID,
		BusinessParticipant_RefID,
		ChargingLevel_RefID,
		WorkTime_InternalIdentifier,
		WorkTime_Source,
		WorkTime_Comment_DictID,
		WorkTime_Amount_min,
		WorkTime_Start,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_BPT_InvestedWorkTimeID,
		@BusinessParticipant_RefID,
		@ChargingLevel_RefID,
		@WorkTime_InternalIdentifier,
		@WorkTime_Source,
		@WorkTime_Comment,
		@WorkTime_Amount_min,
		@WorkTime_Start,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)