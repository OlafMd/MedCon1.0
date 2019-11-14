
	Select
	  cmn_pro_prc_general_averageprocurementprices.Product_RefID,
	  cmn_price_values.PriceValue_Amount,
	  cmn_currencies.Symbol
	From
	  cmn_pro_prc_general_averageprocurementprices Inner Join
	  cmn_price_values On cmn_price_values.Price_RefID =
	    cmn_pro_prc_general_averageprocurementprices.CurrentAverageProcurement_Price_RefID And cmn_price_values.Tenant_RefID = @TenantID And cmn_price_values.IsDeleted = 0 Inner Join
	  cmn_currencies On cmn_price_values.PriceValue_Currency_RefID =
	    cmn_currencies.CMN_CurrencyID
	Where
	  cmn_pro_prc_general_averageprocurementprices.IsDeleted = 0 And
	  cmn_pro_prc_general_averageprocurementprices.Tenant_RefID = @TenantID And
	  cmn_pro_prc_general_averageprocurementprices.IsCurrentAveragePrice = 1
  