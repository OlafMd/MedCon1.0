UPDATE 
	cmn_sls_dynamicpricingformula_types
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	DynamicPricingFormulaType_Name_DictID=@DynamicPricingFormulaType_Name,
	DefaultDynamicPricingFormula=@DefaultDynamicPricingFormula,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_SLS_DynamicPricingFormula_TypeID = @CMN_SLS_DynamicPricingFormula_TypeID