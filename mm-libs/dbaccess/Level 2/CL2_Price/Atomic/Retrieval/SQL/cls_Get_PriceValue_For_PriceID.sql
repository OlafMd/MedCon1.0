
	Select
	  cmn_price_values.PriceValue_Amount
	From
	  cmn_prices Inner Join
	  cmn_price_values On cmn_prices.CMN_PriceID = cmn_price_values.Price_RefID
	Where
	  cmn_prices.CMN_PriceID = @PriceID And
	  cmn_prices.IsDeleted = 0 And
	  cmn_price_values.IsDeleted = 0 And
	  cmn_prices.Tenant_RefID = @TenantID And
	  cmn_price_values.Tenant_RefID = @TenantID
  