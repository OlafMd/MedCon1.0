
	Select
	  cmn_prices.CMN_PriceID,
	  cmn_price_values.PriceValue_Amount,
	  cmn_currencies.Symbol,
	  cmn_currencies.Name_DictID,
	  cmn_currencies.ISO4127,
	  cmn_currencies.CMN_CurrencyID
	From
	  cmn_prices Inner Join
	  cmn_price_values On cmn_price_values.Price_RefID = cmn_prices.CMN_PriceID
	  Inner Join
	  cmn_currencies On cmn_price_values.PriceValue_Currency_RefID =
	    cmn_currencies.CMN_CurrencyID
	Where
	  cmn_prices.Tenant_RefID = @TenantID And
	  cmn_prices.IsDeleted = 0 And
	  cmn_price_values.IsDeleted = 0 And
	  cmn_currencies.IsDeleted = 0 And
	  cmn_prices.CMN_PriceID = @PriceID
  