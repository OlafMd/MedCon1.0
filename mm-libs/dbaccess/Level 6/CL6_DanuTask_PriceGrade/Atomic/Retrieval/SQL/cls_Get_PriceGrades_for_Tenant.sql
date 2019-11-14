
	Select
	  cmn_sls_prices.PriceAmount,
	  cmn_currencies.Name_DictID as CurrencyName,
	  cmn_bpt_investedworktime_charginglevels.ChangingLevel_Name_DictID,
	  cmn_bpt_investedworktime_charginglevels.CMN_BPT_InvestedWorkTime_ChargingLevelID,
	  cmn_bpt_investedworktime_charginglevels.Tenant_RefID
	From
	  cmn_sls_prices Inner Join
	  cmn_pro_products On cmn_sls_prices.CMN_PRO_Product_RefID =
	    cmn_pro_products.CMN_PRO_ProductID Inner Join
	  cmn_bpt_investedworktime_charginglevels
	    On cmn_bpt_investedworktime_charginglevels.CMN_PRO_Product_RefID =
	    cmn_pro_products.CMN_PRO_ProductID Left Join
	  cmn_currencies On cmn_sls_prices.CMN_Currency_RefID =
	    cmn_currencies.CMN_CurrencyID
	Where
	  cmn_bpt_investedworktime_charginglevels.IsDeleted = 0 And
	  cmn_pro_products.IsDeleted = 0 And
	  cmn_sls_prices.IsDeleted = 0 And
	  cmn_sls_prices.Tenant_RefID = @TenantID

  