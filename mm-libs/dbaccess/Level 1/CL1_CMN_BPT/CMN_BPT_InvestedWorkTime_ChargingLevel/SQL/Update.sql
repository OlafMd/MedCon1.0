UPDATE 
	cmn_bpt_investedworktime_charginglevels
SET 
	CMN_PRO_Product_RefID=@CMN_PRO_Product_RefID,
	CMN_PRO_Product_Variant_RefID=@CMN_PRO_Product_Variant_RefID,
	CMN_PRO_Product_Release_RefID=@CMN_PRO_Product_Release_RefID,
	ChangingLevel_Name_DictID=@ChangingLevel_Name,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_BPT_InvestedWorkTime_ChargingLevelID = @CMN_BPT_InvestedWorkTime_ChargingLevelID