
	Select
	  cmn_currencies.CMN_CurrencyID,
	  cmn_currencies.Name_DictID,
	  cmn_currencies.ISO4127,
	  cmn_currencies.Symbol
	From
	  cmn_currencies
	Where
	  cmn_currencies.IsDeleted = 0 And
	  cmn_currencies.Tenant_RefID = @TenantID
  