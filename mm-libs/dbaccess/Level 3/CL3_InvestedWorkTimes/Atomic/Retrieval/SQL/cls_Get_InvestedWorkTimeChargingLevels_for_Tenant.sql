
    
Select
  cmn_bpt_investedworktime_charginglevels.CMN_BPT_InvestedWorkTime_ChargingLevelID,
  cmn_bpt_investedworktime_charginglevels.ChangingLevel_Name_DictID
From
  cmn_bpt_investedworktime_charginglevels
Where
  cmn_bpt_investedworktime_charginglevels.IsDeleted = 0 And
  cmn_bpt_investedworktime_charginglevels.Tenant_RefID = @TenantID
  