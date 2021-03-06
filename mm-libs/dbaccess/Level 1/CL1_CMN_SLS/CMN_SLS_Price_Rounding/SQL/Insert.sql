INSERT INTO 
	cmn_sls_price_rounding
	(
		CMN_SLS_Price_RoundingID,
		PriceRoundingRuleSet_RefID,
		Amount_From,
		Amount_To,
		IsAmountTo_Specified,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@CMN_SLS_Price_RoundingID,
		@PriceRoundingRuleSet_RefID,
		@Amount_From,
		@Amount_To,
		@IsAmountTo_Specified,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)