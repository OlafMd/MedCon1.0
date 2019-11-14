
Select
  cmn_price_values.PriceValue_Amount,
  cmn_currencies.Symbol,
  cmn_currencies.Name_DictID,
  cmn_currencies.ISO4127,
  cmn_currencies.CMN_CurrencyID,
  cmn_price_values.Price_RefID
From
  cmn_price_values Left Join
  cmn_currencies On cmn_price_values.PriceValue_Currency_RefID =
    cmn_currencies.CMN_CurrencyID
Where
  cmn_price_values.Price_RefID = @PriceID And
  cmn_price_values.IsDeleted = 0
  