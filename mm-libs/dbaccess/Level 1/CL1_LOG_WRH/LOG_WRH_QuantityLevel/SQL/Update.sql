UPDATE 
	log_wrh_quantitylevels
SET 
	Quantity_Minimum=@Quantity_Minimum,
	Quantity_RecommendedMinimumCalculation=@Quantity_RecommendedMinimumCalculation,
	Quantity_Maximum=@Quantity_Maximum,
	Product_RefID=@Product_RefID,
	Product_Variant_RefID=@Product_Variant_RefID,
	Product_Release_RefID=@Product_Release_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_WRH_QuantityLevelID = @LOG_WRH_QuantityLevelID