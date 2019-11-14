UPDATE 
	cmn_sls_price_roundingruleset
SET 
	RuleSet_Name_DictID=@RuleSet_Name,
	MaximumPriceIncreaseInPercent=@MaximumPriceIncreaseInPercent,
	MaximumPriceDecreaseInPercent=@MaximumPriceDecreaseInPercent,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_SLS_Price_RoundingRuleSetID = @CMN_SLS_Price_RoundingRuleSetID