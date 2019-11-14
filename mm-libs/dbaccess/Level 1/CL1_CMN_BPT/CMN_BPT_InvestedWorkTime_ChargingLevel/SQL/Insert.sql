INSERT INTO 
	cmn_bpt_investedworktime_charginglevels
	(
		CMN_BPT_InvestedWorkTime_ChargingLevelID,
		CMN_PRO_Product_RefID,
		CMN_PRO_Product_Variant_RefID,
		CMN_PRO_Product_Release_RefID,
		ChangingLevel_Name_DictID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_BPT_InvestedWorkTime_ChargingLevelID,
		@CMN_PRO_Product_RefID,
		@CMN_PRO_Product_Variant_RefID,
		@CMN_PRO_Product_Release_RefID,
		@ChangingLevel_Name,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)