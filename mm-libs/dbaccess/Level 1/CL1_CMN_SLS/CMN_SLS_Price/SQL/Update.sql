UPDATE 
	cmn_sls_prices
SET 
	PricelistRelease_RefID=@PricelistRelease_RefID,
	CMN_PRO_Product_RefID=@CMN_PRO_Product_RefID,
	CMN_PRO_Product_Variant_RefID=@CMN_PRO_Product_Variant_RefID,
	CMN_PRO_Product_Release_RefID=@CMN_PRO_Product_Release_RefID,
	CMN_Currency_RefID=@CMN_Currency_RefID,
	PriceAmount=@PriceAmount,
	IsDynamicPricingUsed=@IsDynamicPricingUsed,
	DynamicPricingFormula_Type_RefID=@DynamicPricingFormula_Type_RefID,
	DynamicPricingFormula=@DynamicPricingFormula,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_SLS_PriceID = @CMN_SLS_PriceID