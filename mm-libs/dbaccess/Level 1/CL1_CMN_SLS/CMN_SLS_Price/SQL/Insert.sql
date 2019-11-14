INSERT INTO 
	cmn_sls_prices
	(
		CMN_SLS_PriceID,
		PricelistRelease_RefID,
		CMN_PRO_Product_RefID,
		CMN_PRO_Product_Variant_RefID,
		CMN_PRO_Product_Release_RefID,
		CMN_Currency_RefID,
		PriceAmount,
		IsDynamicPricingUsed,
		DynamicPricingFormula_Type_RefID,
		DynamicPricingFormula,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@CMN_SLS_PriceID,
		@PricelistRelease_RefID,
		@CMN_PRO_Product_RefID,
		@CMN_PRO_Product_Variant_RefID,
		@CMN_PRO_Product_Release_RefID,
		@CMN_Currency_RefID,
		@PriceAmount,
		@IsDynamicPricingUsed,
		@DynamicPricingFormula_Type_RefID,
		@DynamicPricingFormula,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)