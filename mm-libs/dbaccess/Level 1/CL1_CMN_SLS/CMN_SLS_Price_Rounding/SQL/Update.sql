UPDATE 
	cmn_sls_price_rounding
SET 
	PriceRoundingRuleSet_RefID=@PriceRoundingRuleSet_RefID,
	Amount_From=@Amount_From,
	Amount_To=@Amount_To,
	IsAmountTo_Specified=@IsAmountTo_Specified,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_SLS_Price_RoundingID = @CMN_SLS_Price_RoundingID