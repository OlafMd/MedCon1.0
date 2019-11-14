
	SELECT cmn_sls_price_roundingruleset.CMN_SLS_Price_RoundingRuleSetID,
	       cmn_sls_price_roundingruleset.RuleSet_Name_DictID,
	       cmn_sls_price_roundingruleset.MaximumPriceIncreaseInPercent,
	       cmn_sls_price_roundingruleset.MaximumPriceDecreaseInPercent,
	       cmn_sls_price_rounding.CMN_SLS_Price_RoundingID,
	       cmn_sls_price_rounding.Amount_From,
	       cmn_sls_price_rounding.Amount_To,
	       cmn_sls_price_rounding.IsAmountTo_Specified,
         0 AS IsRoundingDeleted,
	       cmn_sls_price_roundinglevels.CMN_SLS_Price_RoundingLevelID,
	       cmn_sls_price_roundinglevels.RoundingAmount,
	       cmn_sls_price_roundinglevels.IsDeleted
	FROM cmn_sls_price_roundingruleset
	INNER JOIN cmn_sls_price_rounding 
	ON cmn_sls_price_roundingruleset.CMN_SLS_Price_RoundingRuleSetID = cmn_sls_price_rounding.PriceRoundingRuleSet_RefID
	   AND cmn_sls_price_rounding.IsDeleted = 0
	LEFT JOIN cmn_sls_price_roundinglevels 
	ON cmn_sls_price_rounding.CMN_SLS_Price_RoundingID = cmn_sls_price_roundinglevels.Rounding_RefID
	   AND cmn_sls_price_roundinglevels.IsDeleted = 0
	WHERE cmn_sls_price_roundingruleset.IsDeleted = 0
        AND cmn_sls_price_roundingruleset.Tenant_RefID = @TenantID
  ORDER BY cmn_sls_price_rounding.Amount_From, 
           cmn_sls_price_rounding.Amount_To,
           cmn_sls_price_roundinglevels.RoundingAmount
  