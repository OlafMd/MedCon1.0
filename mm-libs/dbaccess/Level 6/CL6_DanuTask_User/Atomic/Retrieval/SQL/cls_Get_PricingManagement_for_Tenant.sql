
Select
  cmn_sls_prices.PriceAmount,
  cmn_bpt_investedworktime_charginglevels.ChangingLevel_Name_DictID,
  cmn_bpt_investedworktime_charginglevels.CMN_BPT_InvestedWorkTime_ChargingLevelID,
  cmn_currencies.Symbol,
  cmn_currencies.Name_DictID,
  cmn_currencies.CMN_CurrencyID,
  cmn_sls_prices.CMN_SLS_PriceID
From
  cmn_sls_prices Left Join
  cmn_currencies On cmn_sls_prices.CMN_Currency_RefID =
    cmn_currencies.CMN_CurrencyID Inner Join
  cmn_bpt_investedworktime_charginglevels
    On cmn_sls_prices.CMN_PRO_Product_RefID =
    cmn_bpt_investedworktime_charginglevels.CMN_PRO_Product_RefID
Where
  cmn_bpt_investedworktime_charginglevels.IsDeleted = 0 And
  cmn_sls_prices.IsDeleted = 0 And
  cmn_bpt_investedworktime_charginglevels.Tenant_RefID = @TenantID
  