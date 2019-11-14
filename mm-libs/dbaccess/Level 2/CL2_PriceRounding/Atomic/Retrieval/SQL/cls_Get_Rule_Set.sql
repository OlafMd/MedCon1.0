
	SELECT
	  cmn_sls_price_roundingruleset.CMN_SLS_Price_RoundingRuleSetID,
	  cmn_sls_price_roundingruleset.RuleSet_Name_DictID,
	  cmn_sls_price_roundingruleset.MaximumPriceIncreaseInPercent,
	  cmn_sls_price_roundingruleset.MaximumPriceDecreaseInPercent,
	  cmn_sls_price_roundingruleset.IsDeleted
	FROM
	  cmn_sls_price_roundingruleset
	WHERE
	  cmn_sls_price_roundingruleset.IsDeleted = 0 AND
	  cmn_sls_price_roundingruleset.Tenant_RefID = @TenantID
  